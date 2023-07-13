using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using TCP_Crypto;
using User = TCP_Crypto.User;

namespace TCP_Server {
	public partial class ServerForm : Form {

		private readonly Thread? serverThread = null;
		private TcpListener? tcpListener = null;
		private readonly Dictionary<string, TcpClient> clients = new();
		private readonly List<Thread> clientThreads = new();
		readonly List<User> users = new();
		bool exit = false;
		static string code_de_synchro = "3dbc60e1-1143-4122-ba56-f6fc6c224156";

		public ServerForm() {
			InitializeComponent();
			if (File.Exists("synchro.txt")) {
				code_de_synchro = File.ReadAllText("synchro.txt");
			}
			richTextBox1.AppendText("CODE DE SYNCHRO SERVEUR : " + BitConverter.ToString(
	SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro[..20]))).Substring(0, 20), Color.Magenta);
			serverThread = new Thread(() => StartServer());
			serverThread.Start();
		}

		#region TCP SERVER
		private void StartServer() {
			try {
				int port = 4242; // Port utilisé par le serveur
				tcpListener = new TcpListener(IPAddress.Any, port);
				tcpListener.Start();
				// Boucle d'attente des connexions clientes
				while (true) {
					if (exit) {
						Invoke((MethodInvoker)delegate {
							richTextBox1.AppendText("EXIT", Color.Orange);
						});
						break;
					}
					TcpClient client = tcpListener.AcceptTcpClient();
					string id = Guid.NewGuid().ToString();

					// Démarrer un nouveau thread pour traiter la connexion cliente
					Thread clientThread = new(() => HandleClientConnection(client, id));
					clientThread.Start();

					// Ajouter le thread client à la liste des threads actifs
					clients.Add(id, client);
					Invoke((MethodInvoker)delegate {
						richTextBox1.AppendText("Nouveau client connecté : " + id, Color.RoyalBlue);
					});
					SendDataToClient(client, "hello world");
					clientThreads.Add(clientThread);
				}
			} catch (Exception ex) {
				Invoke((MethodInvoker)delegate {
					richTextBox1.AppendText(ex.Message, Color.Red);
				});
			}
		}

		private void HandleClientConnection(TcpClient client, string id) {
			try {
				NetworkStream stream = client.GetStream();
				//envoie la liste des utilisateurs a la connexion
				foreach (var user in users) {
					JObject json = new() {
						["nick"] = user.nick,
						["public_RSA"] = user.public_RSA,
						["public_RSA2"] = user.public_RSA2
					};
					Roam roam = new Roam() { route = "new:user", payload = JsonConvert.SerializeObject(json, Formatting.None) };
					SendDataToClient(client, JsonConvert.SerializeObject(roam));
				}
				bool run = true;
				// Boucle de traitement de la connexion cliente
				while (run) {
					try {
						// Lire les données du client
						byte[] buffer = new byte[2 ^ 20];
						List<byte> data = new();
						int totalBytesReceived = 0;
						int expectedDataSize = 0;
						while (true) {
							int bytesRead = stream.Read(buffer, 0, buffer.Length);
							if (bytesRead == 0) {
								run = false;
								break;
							}
							totalBytesReceived += bytesRead;
							data.AddRange(buffer.Take(bytesRead));

							if (totalBytesReceived >= 4 && expectedDataSize == 0) {
								// Extract the expected data size from the first 4 bytes
								expectedDataSize = BitConverter.ToInt32(buffer, 0);
							}
							if (totalBytesReceived >= expectedDataSize + 4) {
								byte[] bin = data.Skip(4).Take(expectedDataSize).ToArray();

								byte[] xor = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro));
								Aes local = Aes.Create();
								local.Key = xor;
								local.IV = SHA256.Create().ComputeHash(xor).Take(local.IV.Length).ToArray();
								bin = local.DecryptCfb(bin, local.IV);

								// All data received, process the received bytes
								ProcessDataPacket(Encoding.UTF8.GetString(bin), id);
								data = data.Skip(4 + expectedDataSize).ToList();
								if (data.Count > 0) {
									expectedDataSize = 0;
									totalBytesReceived = data.Count;
								} else {
									break;
								}
							}
						}
					} catch (Exception ex) {
						Invoke((MethodInvoker)delegate {
							richTextBox1.AppendText(id + " : " + ex.Message + "\n" + ex.StackTrace, Color.Red);
						});
					}
				}
				if (users.Any(x => x.id == id)) {
					User u = users.First(x => x.id == id);
					JObject js = new() {
						["nick"] = u.nick,
					};
					Roam r = new Roam() { route = "close:user", payload = JsonConvert.SerializeObject(js, Formatting.None) };
					foreach (var cli in clients.Where(x => x.Key != id)) {
						SendDataToClient(cli.Value, JsonConvert.SerializeObject(r));
					}
					users.Remove(u);
				}
				Invoke((MethodInvoker)delegate {
					richTextBox1.AppendText("CLOSING " + id + " online = " + users.Count, Color.Yellow);
				});
				client.Close();
				clients.Remove(id);
			} catch (Exception ex) {
				Invoke((MethodInvoker)delegate {
					richTextBox1.AppendText(ex.Message, Color.DarkOrange);
				});
			}
		}
		private void ProcessDataPacket(string data, string id) {
			Roam roam = JsonConvert.DeserializeObject<Roam>(data)!;
			Roaming(roam, id);
		}

		#endregion

		void Roaming(Roam roam, string clientId) {
			JObject json = JObject.Parse(roam.payload);

			switch (roam.route) {
				case "register":
					Identify((string)json["nick"]!, (string)json["public_RSA"]!, (string)json["public_RSA2"]!, clientId);
					break;
				case "send:message":
					User to = users.Find(x => x.nick == (string)json["to"]!)!;
					string from = users.Find(x => x.id == clientId)!.nick;
					json["from"] = from;
					Roam r = new Roam() { payload = JsonConvert.SerializeObject(json), route = "new:message" };
					byte[] bin = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(r));
					SendDataToClient(clients[to.id], JsonConvert.SerializeObject(r));
					break;
				default: throw new Exception("No roam found : " + roam.route);
			}
		}

		void SendDataToClient(TcpClient client, string data) {
			byte[] bin = Encoding.UTF8.GetBytes(data);

			byte[] xor = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro));
			Aes local = Aes.Create();
			local.Key = xor;
			local.IV = SHA256.Create().ComputeHash(xor).Take(local.IV.Length).ToArray();
			bin = local.EncryptCfb(bin, local.IV);

			int dataSize = bin.Length;
			byte[] dataSizeBytes = BitConverter.GetBytes(dataSize);
			client.GetStream().Write(dataSizeBytes, 0, 4);
			client.GetStream().Write(bin, 0, bin.Length);
		}

		void Identify(string nick, string public_RSA, string public_RSA2, string id) {
			if (users.Find(x => x.id == id) == null) {
				users.Add(new User() { nick = nick, public_RSA = public_RSA, public_RSA2 = public_RSA2, id = id });
			} else {
				JObject json = new() {
					["err"] = "Nom d'utilisateur déjà enregistré.",
				};
				Roam roam = new() { route = "error", payload = JsonConvert.SerializeObject(json, Formatting.None) };
				SendDataToClient(clients[id], JsonConvert.SerializeObject(roam));
				return;
			}
			foreach (var client in clients) {
				JObject json = new() {
					["nick"] = nick,
					["public_RSA"] = public_RSA,
					["public_RSA2"] = public_RSA2,
				};
				Roam roam = new() { route = "new:user", payload = JsonConvert.SerializeObject(json, Formatting.None) };
				SendDataToClient(client.Value, JsonConvert.SerializeObject(roam));
			}
			Invoke((MethodInvoker)delegate {
				richTextBox1.AppendText("Identified : " + nick + " for " + id, Color.LightBlue);
			});
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			if (tcpListener != null) {
				// Arrêter le thread d'écoute du serveur
				foreach (var item in clients) {
					item.Value.Close();
				}
				tcpListener.Stop();
			}
			exit = true;
		}
	}
}

public static class RichTextBoxExtensions {
	internal static void AppendText(this RichTextBox box, string text, Color color, bool AddNewLine = true) {
		box.SuspendLayout();
		box.SelectionStart = box.TextLength;
		box.SelectionLength = 0;

		box.SelectionColor = color;
		if (AddNewLine) text += Environment.NewLine;
		box.AppendText(text);
		box.SelectionColor = box.ForeColor;
		box.ScrollToCaret();

		box.ResumeLayout();
	}
}