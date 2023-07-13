using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using TCP_Crypto;
using User = TCP_Crypto.User;

namespace TCP_Dialog {
	public partial class ClientForm : Form {

		private TcpClient? tcpClient = null;
		private Thread? clientThread = null;
		readonly RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
		readonly AsymmetricCipherKeyPair rsa2;
		public List<User> users = new List<User>();
		static readonly string animals = "Chat;Chien;Lion;Tigre;Éléphant;Girafe;Gorille;Singe;Zèbre;Hippopotame;Rhinocéros;Ours;Loup;Renard;Lapin;Kangourou;Koala;Panda;Crocodile;Alligator;Serpent;Tortue;Dauphin;Baleine;Requin;Épaulard;Orque;Poisson;Perroquet;Aigle;Hibou;Canard;Oie;Pingouin;Flamant rose;Paon;Autruche;Toucan;Grenouille;Crapaud;Salamandre;Gecko;Araignée;Scorpion;Libellule;Papillon;Abeille;Fourmi;Guêpe;Coccinelle;Ara;Gazelle;Chameau;Lama;Oryx;Gnou;Phacochère;Hyène;Ane;Cheval;Mouton;Vache;Cochon;Poulet;Canari;Pigeon;Corbeau;Mouette;Écureuil;Castor;Opossum;Koala;Chauve-souris;Raton laveur;Loutre;Écureuil volant;Tatou;Antilope;Gazelle;Babouin;Porc-épic;Panthère;Léopard;Puma;Jaguar;Lézard;Iguane;Baleine à bosse;Étoile de mer;Méduse;Crabe;Homard;Bernache du Canada;Ours polaire;Renne;Léopard des neiges;Lama;Dromadaire;Ocelot;Dingo";
		static readonly string colors = "Rouge;Bleu;Vert;Jaune;Rose;Violet;Orange;Noir;Blanc;Gris;Marron;Beige;Turquoise;Bleu marine;Saumon;Indigo;Émeraude;Citron vert;Fuchsia;Cramoisi;Cyan;Sable;Doré;Argenté;Pourpre;Olive;Corail;Lavande;Teal;Azur;Bronze;Mauve;Sarcelle;Brun clair;Pêche;Rouille;Gris anthracite;Chartreuse;Terracotta;Bordeaux;Rose bonbon;Or;Chocolat;Aigue-marine;Vert olive;Lilas;Menthe;Jaune pâle;Noir de jais;Ciel;Corail;Brun chocolat;Ambre;Magenta;Perle;Vert émeraude;Pervenche;Citrouille;Roux;Indigo foncé;Rose poudré;Améthyste;Vert forêt;Gris perle;Corail rose;Safran;Vert menthe;Gris souris;Vanille;Mordoré;Rouge cerise;Vert lime;Sauge;Olive foncé;Ivoire;Bleu cobalt;Cannelle;Gris foncé;Jaune vif;Vert pomme;Turquoise clair;Bleu ciel;Vert citron;Abricot;Gris clair;Aubergine;Vert pin;Saumon foncé;Prune;Bleu nuit;Caramel;Bleu royal;Sienne;Bleu ardoise;Fauve;Vert jade;Roux foncé;Gris ardoise;Bronze;Bleu turquoise";
		static string code_de_synchro = "3dbc60e1-1143-4122-ba56-f6fc6c224156";

		public ClientForm() {
			InitializeComponent();
			KeyGenerationParameters keyGenerationParameters = new KeyGenerationParameters(new SecureRandom(), 2048);
			RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
			keyPairGenerator.Init(keyGenerationParameters);
			rsa2 = keyPairGenerator.GenerateKeyPair();
			if (File.Exists("synchro.txt")) {
				code_de_synchro = File.ReadAllText("synchro.txt");
			}
			output_field.AppendText("CODE DE SYNCHRO SERVEUR : " + BitConverter.ToString(
	SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro[..20]))).Substring(0, 20), ColorFromHash(Encoding.UTF8.GetBytes(code_de_synchro[..20])));
			Random r = new();
			nickTB.Text = animals.Split(';')[r.Next() % animals.Split(';').Length].ToUpper() + " " + colors.Split(';')[r.Next() % colors.Split(';').Length].ToUpper();
			label1.ForeColor = ColorFromHash(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(nickTB.Text)));
			nickTB.ForeColor = label1.ForeColor;
			Thread serverThread = new(() => ConnectToServer());
			serverThread.Start();
		}

		public static byte[] HashName(string name) {
			return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(name));
		}
		public static Color ColorFromHash(byte[] hash) {
			int r = hash[0];
			int g = hash[1];
			int b = hash[2];
			while (r + g + b < 400) {
				if (r < 255) r++;
				if (g < 255) g++;
				if (b < 255) b++;
			}
			return Color.FromArgb(r, g, b);
		}

		private void ConnectToServer() {
			try {
				tcpClient = new TcpClient();
				string realm = File.ReadAllText("realmlist.txt");
				tcpClient.Connect(realm.Split(':')[0], int.Parse(realm.Split(':')[1]));

				// Démarrer le thread du client pour recevoir les données en arrière-plan
				clientThread = new Thread(ReceiveData);
				clientThread.Start();
			} catch (Exception ex) {
				// Gestion des erreurs de connexion
				Invoke((MethodInvoker)delegate {
					output_field.AppendText(ex.Message, Color.Orange);
				});
			}
		}
		public void SendDataToServer(string data) {
			try {
				NetworkStream stream = tcpClient!.GetStream();
				// Convertir les données en tableau d'octets
				byte[] bin = Encoding.UTF8.GetBytes(data);

				byte[] xor = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro));
				Aes local = Aes.Create();
				local.Key = xor;
				local.IV = SHA256.Create().ComputeHash(xor).Take(local.IV.Length).ToArray();
				bin = local.EncryptCfb(bin, local.IV);

				int dataSize = bin.Length;
				byte[] dataSizeBytes = BitConverter.GetBytes(dataSize);
				stream.Write(dataSizeBytes, 0, 4);
				stream.Write(bin, 0, bin.Length);
			} catch (Exception ex) {
				Invoke((MethodInvoker)delegate {
					output_field.AppendText(ex.Message, Color.Orange);
				});
			}
		}
		private void ReceiveData() {
			try {
				NetworkStream stream = tcpClient!.GetStream();
				// Boucle de réception des données
				bool run = true;
				while (run) {
					try {
						// Lire les données du flux
						byte[] buffer = new byte[2 ^ 20];
						int totalBytesReceived = 0;
						int expectedDataSize = 0;
						List<byte> data = new();
						float percent = 0;

						while (true) {
							int bytesRead = stream.Read(buffer, 0, buffer.Length);
							if (bytesRead == 0) {
								run = false;
								break;
							}
							totalBytesReceived += bytesRead;
							data.AddRange(buffer.Take(bytesRead));
							if (totalBytesReceived >= 4 && expectedDataSize == 0) {
								expectedDataSize = BitConverter.ToInt32(data.ToArray(), 0);
								Invoke((MethodInvoker)delegate {
									progressBar1.Visible = true;
									label2.Visible = true;
								});
							}
							float p = ((float)totalBytesReceived / (expectedDataSize + 4)) * 100;
							if (p > percent + 5) {
								Invoke((MethodInvoker)delegate {
									progressBar1.Value = Math.Min((int)p, progressBar1.Maximum);
								});
								percent = p;
							}
							if (totalBytesReceived >= expectedDataSize + 4) {
								Invoke((MethodInvoker)delegate {
									progressBar1.Value = 0;
									percent = 0;
									progressBar1.Visible = false;
									label2.Visible = false;
								});

								byte[] bin = data.Skip(4).Take(expectedDataSize).ToArray();
								byte[] xor = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(code_de_synchro));
								Aes local = Aes.Create();
								local.Key = xor;
								local.IV = SHA256.Create().ComputeHash(xor).Take(local.IV.Length).ToArray();
								bin = local.DecryptCfb(bin, local.IV);

								ProcessDataPacket(Encoding.UTF8.GetString(bin));
								data = data.Skip(4 + expectedDataSize).ToList();
								if (data.Count > 0) {
									expectedDataSize = 0;
									totalBytesReceived = data.Count;
								} else {
									break;
								}
							}
						}
						if (tcpClient.Client.Poll(0, SelectMode.SelectRead)) {
							byte[] checkBuffer = new byte[1];
							if (tcpClient.Client.Receive(checkBuffer, SocketFlags.Peek) == 0) {
								// Connection closed by the server
								break;
							}
						}
					} catch (Exception ex) {
						Invoke((MethodInvoker)delegate {
							output_field.AppendText(ex.Message + "\n" + ex.StackTrace, Color.DarkOrange);
						});
						tcpClient.Close();
						return;
					}
				}
				tcpClient.Close();
				Invoke((MethodInvoker)delegate {
					output_field.AppendText("Server closed. Please start the server and restart this program.", Color.Red);
				});
			} catch (Exception ex) {
				Invoke((MethodInvoker)delegate {
					output_field.AppendText(ex.Message + "\n" + ex.StackTrace, Color.DarkOrange);
				});
			}
		}
		private void ProcessDataPacket(string data) {
			if (data == "hello world") {
				Invoke((MethodInvoker)delegate {
					RegisterBT.Enabled = true;
				});
				//tcpClient.Close();
				return;
			}
			// Convertir les données en chaîne de texte
			try {
				Roam roam = JsonConvert.DeserializeObject<Roam>(data)!;
				Roaming(roam);
			} catch (Exception ex) {
				Invoke((MethodInvoker)delegate {
					output_field.AppendText(data, Color.Red);
				});
			}
		}

		bool auth = false;
		void Roaming(Roam roam) {
			JObject json = JObject.Parse(roam.payload);

			switch (roam.route) {
				case "new:user":
					if ((string)json["nick"]! == nickTB.Text) {
						auth = true;
						Invoke((MethodInvoker)delegate {
							send_BT.Enabled = auth && users.Count > 0;
							output_field.AppendText("Connecté au serveur !", Color.Lime);
							nickTB.ReadOnly = true;
							RegisterBT.Visible = false;
						});
						break;
					}
					users.Add(new User() { nick = (string)json["nick"]!, public_RSA = (string)json["public_RSA"]!, public_RSA2= (string)json["public_RSA2"]! });
					Invoke((MethodInvoker)delegate {
						send_BT.Enabled = auth;
						output_field.AppendText("Utilisateur en ligne : " + (string)json["nick"]!, Color.RoyalBlue);
					});
					label_online.Text = users.Count + " utilisateurs en ligne.";
					break;
				case "close:user":
					users = users.Where(x => x.nick != (string)json["nick"]!).ToList();
					Invoke((MethodInvoker)delegate {
						send_BT.Enabled = users.Count > 0 && auth;
						output_field.AppendText("Utilisateur déconnecté : " + (string)json["nick"]!, Color.Orange);
					});
					label_online.Text = users.Count + " utilisateurs en ligne.";
					break;
				case "new:message":
					byte[] aes_key = rsa.Decrypt(Convert.FromBase64String((string)json["aes_key"]!), true);
					byte[] aes_iv = rsa.Decrypt(Convert.FromBase64String((string)json["aes_IV"]!), true);
					byte[] aes_key2 = BouncyCastle.RSA_Decrypt(Convert.FromBase64String((string)json["aes_key2"]!), rsa2.Private);
					Aes aes = Aes.Create();
					aes.Key = aes_key;
					aes.IV = aes_iv;
					string filename = Encoding.UTF8.GetString(aes.DecryptCbc(BouncyCastle.AES_Decrypt(Convert.FromBase64String((string)json["filename"]!), aes_key2), aes.IV));
					var bin = aes.DecryptCbc(BouncyCastle.AES_Decrypt(Convert.FromBase64String((string)json["cipher"]!), aes_key2), aes.IV);
					
					if (filename == "") {
						string plain = Encoding.UTF8.GetString(bin);
						Invoke((MethodInvoker)delegate {
							output_field.AppendText("De : " + (string)json["from"]! + $" ({DateTime.UtcNow.Hour:00}h{DateTime.UtcNow.Minute:00}):\n" + plain, ColorFromHash(HashName((string)json["from"]!)));
						});
					} else {
						string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), (string)json["from"]!, filename);
						string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), (string)json["from"]!);
						if (!Directory.Exists(dir)) {
							Directory.CreateDirectory(dir);
						}
						File.WriteAllBytes(path, bin);
						Invoke((MethodInvoker)delegate {
							output_field.AppendText("De : " + (string)json["from"]! + $" ({DateTime.UtcNow.Hour:00}h{DateTime.UtcNow.Minute:00}):\nFichier reçu : " + path, ColorFromHash(HashName((string)json["from"]!)));
						});
					}
					break;
				case "error":
					Invoke((MethodInvoker)delegate {
						output_field.AppendText("Erreur : " + (string)json["err"]!, Color.Red);
					});
					break;
				default: throw new Exception("No roam found");
			}
		}

		internal void AppendTxt(string txt, Color col) {
			output_field.AppendText(txt, col);
		}

		private void RegisterClick(object sender, EventArgs e) {
			JObject json = new JObject();
			json["nick"] = nickTB.Text;
			json["public_RSA"] = Convert.ToBase64String(rsa.ExportCspBlob(false));
			SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(rsa2.Public);
			json["public_RSA2"] = Convert.ToBase64String(publicKeyInfo.GetEncoded());
			Roam roam = new Roam() { route = "register", payload = JsonConvert.SerializeObject(json, Formatting.None) };
			SendDataToServer(JsonConvert.SerializeObject(roam));
		}

		private void RedactClick(object sender, EventArgs e) {
			RedactForm rf = new RedactForm(this);
			rf.Show();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			if (tcpClient != null) {
				tcpClient.Close();
			}
		}

		private void nickTB_TextChanged(object sender, EventArgs e) {
			label1.ForeColor = ColorFromHash(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(nickTB.Text)));
			nickTB.ForeColor = label1.ForeColor;
			RegisterBT.Enabled = nickTB.Text.Length > 3;
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