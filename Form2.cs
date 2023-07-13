using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalEncryptor {
	public partial class Form2 : Form {
		public Form2() {
			InitializeComponent();
		}
		public string api_key = "";
		public string token = "";
		private static readonly HttpClient client = new HttpClient();

		public async void GetToken() {
			var content = new FormUrlEncodedContent(new Dictionary<string, string>{
						{ "api_dev_key", textBox1.Text},
						{ "api_user_name", textBox2.Text },
						{ "api_user_password", textBox3.Text },
			});

			//POST the object to the specified URI 
			var response = await client.PostAsync("https://pastebin.com/api/api_login.php", content);

			//Read back the answer from server
			var responseString = await response.Content.ReadAsStringAsync();
			Console.WriteLine("AUTH PASTE : " + responseString);
			if (responseString.Contains("Bad API request")) {
				label4.Text = responseString;
				return;
			}
			token = responseString;
			api_key = textBox1.Text;
			Close();
		}

		private void button1_Click(object sender, EventArgs e) {
			GetToken();
		}

		private void button2_Click(object sender, EventArgs e) {
			token = "localhost";
			api_key = "localhost";
			Close();
		}
	}
}
