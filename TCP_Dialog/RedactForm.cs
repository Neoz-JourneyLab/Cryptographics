using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using TCP_Crypto;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Parameters;

namespace TCP_Dialog {
	public partial class RedactForm : Form {

		ClientForm form;
		public RedactForm(ClientForm form) {
			InitializeComponent();
			this.form = form;
			comboBox1.Items.AddRange(form.users.Select(x => x.nick).ToArray());
			label1.Text = "Destinataire (" + form.users.Count + " en ligne)";
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			SetSendEnabled();
			sendFile.ForeColor = ClientForm.ColorFromHash(ClientForm.HashName(comboBox1.Text));
			sendMessage.ForeColor = sendFile.ForeColor;
			label1.ForeColor = sendFile.ForeColor;
			comboBox1.ForeColor = sendFile.ForeColor;
		}

		bool changed = false;
		private void richTextBox1_TextChanged(object sender, EventArgs e) {
			if (inputField.Text.ToLower() != "message...") changed = true;
			SetSendEnabled();
		}

		void SetSendEnabled() {
			inputField.ReadOnly = !form.users.Any(x => x.nick == comboBox1.Text);
			inputField.ForeColor = inputField.ReadOnly ? Color.DarkGray : Color.White;
			sendMessage.Enabled = inputField.Text.Length > 0 && changed;
			sendFile.Enabled = !inputField.ReadOnly;
		}

		private void button1_Click(object sender, EventArgs e) {
			SendMessage(Encoding.UTF8.GetBytes(inputField.Text), Array.Empty<byte>());
			inputField.Text = "";
		}

		void SendMessage(byte[] plain, byte[] filename) {
			User user = form.users.First(x => x.nick == comboBox1.Text);
			Aes aes = Aes.Create();
			RSACryptoServiceProvider public_rsa = new();
			byte[] aes_key2 = SHA256.Create().ComputeHash(BouncyCastle.GenerateRandomBytes(256));
			public_rsa.ImportCspBlob(Convert.FromBase64String(user.public_RSA));
			string encrypted = Convert.ToBase64String(BouncyCastle.AES_Encrypt(aes.EncryptCbc(plain, aes.IV), aes_key2));

			JObject json = new() {
				["filename"] = Convert.ToBase64String(BouncyCastle.AES_Encrypt(aes.EncryptCbc(filename, aes.IV), aes_key2)),
				["to"] = comboBox1.Text,
				["aes_IV"] = Convert.ToBase64String(public_rsa.Encrypt(aes.IV, true)),
				["aes_key"] = Convert.ToBase64String(public_rsa.Encrypt(aes.Key, true)),
				["aes_key2"] = Convert.ToBase64String(BouncyCastle.RSA_Encrypt(aes_key2, Convert.FromBase64String(user.public_RSA2))),
				["cipher"] = encrypted
			};
			Roam roam = new() { route = "send:message", payload = JsonConvert.SerializeObject(json, Formatting.None) };
			form.SendDataToServer(JsonConvert.SerializeObject(roam));
			string gdh = $" ({DateTime.UtcNow.Hour:00}h{DateTime.UtcNow.Minute:00}):\n";
			Color col = ClientForm.ColorFromHash(ClientForm.HashName(comboBox1.Text));
			if (Encoding.UTF8.GetString(filename) != "") {
				form.AppendTxt("> FICHIER ENVOYÉ A : " + comboBox1.Text + gdh + Encoding.UTF8.GetString(filename), col);
			} else {
				form.AppendTxt("> MESSAGE ENVOYÉ A : " + comboBox1.Text + gdh + inputField.Text, col);
			}
		}

		private void inputField_MouseClick(object sender, MouseEventArgs e) {
			inputField.SelectAll();
		}

		private void button2_Click(object sender, EventArgs e) {
			label2.Visible = false;

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Sélectionner un fichier";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				string selectedFilePath = openFileDialog.FileName;
				SendMessage(File.ReadAllBytes(selectedFilePath), Encoding.UTF8.GetBytes(openFileDialog.SafeFileName));
				label2.Visible = true;
			}
		}

		private void comboBox1_DrawItem(object sender, DrawItemEventArgs e) {
			// Draw the background 
			e.DrawBackground();

			// Get the item text    
			string text = ((ComboBox)sender).Items[e.Index].ToString();
			Color col = ClientForm.ColorFromHash(ClientForm.HashName(text));
			// Determine the forecolor based on whether or not the item is selected    
			Brush brush = new SolidBrush(col);

			// Draw the text    
			e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
		}
	}
}
