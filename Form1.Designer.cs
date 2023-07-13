namespace UniversalEncryptor {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.key_phrase_txt = new System.Windows.Forms.RichTextBox();
			this.LoadData = new System.Windows.Forms.Button();
			this.data_txt = new System.Windows.Forms.RichTextBox();
			this.SaveData = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.panel1Register = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3PasswordStrong = new System.Windows.Forms.Label();
			this.pass1Tb = new System.Windows.Forms.TextBox();
			this.CreatePasse = new System.Windows.Forms.Button();
			this.pass2Tb = new System.Windows.Forms.TextBox();
			this.panel2Auth = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.passAuthTb = new System.Windows.Forms.TextBox();
			this.label3ErrPass = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.decryptedText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.demoAesKeyRsa = new System.Windows.Forms.RichTextBox();
			this.demoEncrypted = new System.Windows.Forms.RichTextBox();
			this.demoRSA = new System.Windows.Forms.RichTextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.demoHashKey = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.demoHexaKey = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.demoKey = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.demoTxt = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.demoIV = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.demoHexaTxt = new System.Windows.Forms.TextBox();
			this.MainPanel.SuspendLayout();
			this.panel1Register.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2Auth.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// key_phrase_txt
			// 
			this.key_phrase_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.key_phrase_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.key_phrase_txt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.key_phrase_txt.Font = new System.Drawing.Font("Consolas", 11.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			this.key_phrase_txt.ForeColor = System.Drawing.Color.LightBlue;
			this.key_phrase_txt.Location = new System.Drawing.Point(0, 461);
			this.key_phrase_txt.Name = "key_phrase_txt";
			this.key_phrase_txt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.key_phrase_txt.Size = new System.Drawing.Size(1269, 257);
			this.key_phrase_txt.TabIndex = 0;
			this.key_phrase_txt.Text = "Secret key phrase";
			this.key_phrase_txt.TextChanged += new System.EventHandler(this.key_phrase_textChanged);
			// 
			// LoadData
			// 
			this.LoadData.Dock = System.Windows.Forms.DockStyle.Top;
			this.LoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoadData.ForeColor = System.Drawing.Color.SpringGreen;
			this.LoadData.Location = new System.Drawing.Point(0, 26);
			this.LoadData.Name = "LoadData";
			this.LoadData.Size = new System.Drawing.Size(1269, 35);
			this.LoadData.TabIndex = 6;
			this.LoadData.Text = "Load encrypted data";
			this.LoadData.UseVisualStyleBackColor = true;
			this.LoadData.Click += new System.EventHandler(this.LoadEncryptedData);
			// 
			// data_txt
			// 
			this.data_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
			this.data_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.data_txt.Dock = System.Windows.Forms.DockStyle.Top;
			this.data_txt.Font = new System.Drawing.Font("Consolas", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.data_txt.ForeColor = System.Drawing.Color.DarkGray;
			this.data_txt.Location = new System.Drawing.Point(0, 91);
			this.data_txt.Name = "data_txt";
			this.data_txt.Size = new System.Drawing.Size(1269, 335);
			this.data_txt.TabIndex = 7;
			this.data_txt.Text = "Clear data...";
			this.data_txt.TextChanged += new System.EventHandler(this.data_txt_TextChanged);
			// 
			// SaveData
			// 
			this.SaveData.Dock = System.Windows.Forms.DockStyle.Top;
			this.SaveData.Enabled = false;
			this.SaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveData.ForeColor = System.Drawing.Color.SpringGreen;
			this.SaveData.Location = new System.Drawing.Point(0, 426);
			this.SaveData.Name = "SaveData";
			this.SaveData.Size = new System.Drawing.Size(1269, 35);
			this.SaveData.TabIndex = 9;
			this.SaveData.Text = "Save encrypted data";
			this.SaveData.UseVisualStyleBackColor = true;
			this.SaveData.Click += new System.EventHandler(this.SaveSecretDataClickAsync);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.checkBox1.ForeColor = System.Drawing.Color.Gold;
			this.checkBox1.Location = new System.Drawing.Point(0, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(1269, 26);
			this.checkBox1.TabIndex = 10;
			this.checkBox1.Text = "Save online";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.LightBlue;
			this.button1.Location = new System.Drawing.Point(0, 61);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(1269, 30);
			this.button1.TabIndex = 13;
			this.button1.Text = "Add random password";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.key_phrase_txt);
			this.MainPanel.Controls.Add(this.SaveData);
			this.MainPanel.Controls.Add(this.data_txt);
			this.MainPanel.Controls.Add(this.button1);
			this.MainPanel.Controls.Add(this.LoadData);
			this.MainPanel.Controls.Add(this.checkBox1);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1269, 718);
			this.MainPanel.TabIndex = 15;
			// 
			// panel1Register
			// 
			this.panel1Register.Controls.Add(this.groupBox1);
			this.panel1Register.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1Register.Location = new System.Drawing.Point(0, 0);
			this.panel1Register.Name = "panel1Register";
			this.panel1Register.Size = new System.Drawing.Size(1269, 718);
			this.panel1Register.TabIndex = 16;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3PasswordStrong);
			this.groupBox1.Controls.Add(this.pass1Tb);
			this.groupBox1.Controls.Add(this.CreatePasse);
			this.groupBox1.Controls.Add(this.pass2Tb);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ForeColor = System.Drawing.Color.LightBlue;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1269, 189);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Create account";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Lime;
			this.label1.Location = new System.Drawing.Point(25, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "STRONG UNIQUE PASSWORD";
			// 
			// label3PasswordStrong
			// 
			this.label3PasswordStrong.AutoSize = true;
			this.label3PasswordStrong.ForeColor = System.Drawing.Color.Orange;
			this.label3PasswordStrong.Location = new System.Drawing.Point(25, 130);
			this.label3PasswordStrong.Name = "label3PasswordStrong";
			this.label3PasswordStrong.Size = new System.Drawing.Size(280, 22);
			this.label3PasswordStrong.TabIndex = 4;
			this.label3PasswordStrong.Text = "Password not strong enought";
			this.label3PasswordStrong.Visible = false;
			// 
			// pass1Tb
			// 
			this.pass1Tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.pass1Tb.ForeColor = System.Drawing.Color.Lime;
			this.pass1Tb.Location = new System.Drawing.Point(25, 50);
			this.pass1Tb.Name = "pass1Tb";
			this.pass1Tb.Size = new System.Drawing.Size(510, 29);
			this.pass1Tb.TabIndex = 0;
			this.pass1Tb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// CreatePasse
			// 
			this.CreatePasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreatePasse.ForeColor = System.Drawing.Color.Lime;
			this.CreatePasse.Location = new System.Drawing.Point(351, 120);
			this.CreatePasse.Name = "CreatePasse";
			this.CreatePasse.Size = new System.Drawing.Size(184, 43);
			this.CreatePasse.TabIndex = 3;
			this.CreatePasse.Text = "Validate";
			this.CreatePasse.UseVisualStyleBackColor = true;
			this.CreatePasse.Click += new System.EventHandler(this.CreatePasse_Click);
			// 
			// pass2Tb
			// 
			this.pass2Tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.pass2Tb.ForeColor = System.Drawing.Color.Lime;
			this.pass2Tb.Location = new System.Drawing.Point(25, 85);
			this.pass2Tb.Name = "pass2Tb";
			this.pass2Tb.Size = new System.Drawing.Size(510, 29);
			this.pass2Tb.TabIndex = 2;
			this.pass2Tb.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// panel2Auth
			// 
			this.panel2Auth.Controls.Add(this.groupBox2);
			this.panel2Auth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2Auth.Location = new System.Drawing.Point(0, 0);
			this.panel2Auth.Name = "panel2Auth";
			this.panel2Auth.Size = new System.Drawing.Size(1269, 718);
			this.panel2Auth.TabIndex = 17;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.passAuthTb);
			this.groupBox2.Controls.Add(this.label3ErrPass);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ForeColor = System.Drawing.Color.LightBlue;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1269, 182);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Authenticate";
			// 
			// passAuthTb
			// 
			this.passAuthTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.passAuthTb.ForeColor = System.Drawing.Color.Lime;
			this.passAuthTb.Location = new System.Drawing.Point(36, 68);
			this.passAuthTb.Name = "passAuthTb";
			this.passAuthTb.PasswordChar = '*';
			this.passAuthTb.Size = new System.Drawing.Size(510, 29);
			this.passAuthTb.TabIndex = 0;
			this.passAuthTb.Text = "AZErty123456!01";
			// 
			// label3ErrPass
			// 
			this.label3ErrPass.AutoSize = true;
			this.label3ErrPass.ForeColor = System.Drawing.Color.Red;
			this.label3ErrPass.Location = new System.Drawing.Point(36, 110);
			this.label3ErrPass.Name = "label3ErrPass";
			this.label3ErrPass.Size = new System.Drawing.Size(170, 22);
			this.label3ErrPass.TabIndex = 4;
			this.label3ErrPass.Text = "INVALID PASSWORD";
			this.label3ErrPass.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Lime;
			this.label2.Location = new System.Drawing.Point(36, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 22);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.Color.Lime;
			this.button3.Location = new System.Drawing.Point(362, 103);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(184, 43);
			this.button3.TabIndex = 3;
			this.button3.Text = "Authentification";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.GetPrivatePhrase);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1269, 718);
			this.panel1.TabIndex = 17;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.decryptedText);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.demoAesKeyRsa);
			this.groupBox3.Controls.Add(this.demoEncrypted);
			this.groupBox3.Controls.Add(this.demoRSA);
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.demoHashKey);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.demoHexaKey);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.demoKey);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.demoTxt);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.demoIV);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.demoHexaTxt);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.ForeColor = System.Drawing.Color.LightBlue;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1269, 604);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "AES";
			// 
			// decryptedText
			// 
			this.decryptedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.decryptedText.ForeColor = System.Drawing.Color.White;
			this.decryptedText.Location = new System.Drawing.Point(176, 552);
			this.decryptedText.Name = "decryptedText";
			this.decryptedText.Size = new System.Drawing.Size(1077, 29);
			this.decryptedText.TabIndex = 26;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Lime;
			this.label4.Location = new System.Drawing.Point(12, 559);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(150, 22);
			this.label4.TabIndex = 25;
			this.label4.Text = "Decrypted text";
			// 
			// demoAesKeyRsa
			// 
			this.demoAesKeyRsa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoAesKeyRsa.ForeColor = System.Drawing.Color.Lime;
			this.demoAesKeyRsa.Location = new System.Drawing.Point(586, 411);
			this.demoAesKeyRsa.Name = "demoAesKeyRsa";
			this.demoAesKeyRsa.Size = new System.Drawing.Size(671, 124);
			this.demoAesKeyRsa.TabIndex = 24;
			this.demoAesKeyRsa.Text = "";
			this.demoAesKeyRsa.TextChanged += new System.EventHandler(this.demoAesKeyRsa_TextChanged);
			// 
			// demoEncrypted
			// 
			this.demoEncrypted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoEncrypted.ForeColor = System.Drawing.Color.Lime;
			this.demoEncrypted.Location = new System.Drawing.Point(207, 297);
			this.demoEncrypted.Name = "demoEncrypted";
			this.demoEncrypted.Size = new System.Drawing.Size(1050, 69);
			this.demoEncrypted.TabIndex = 23;
			this.demoEncrypted.Text = "";
			// 
			// demoRSA
			// 
			this.demoRSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoRSA.ForeColor = System.Drawing.Color.Gold;
			this.demoRSA.Location = new System.Drawing.Point(12, 372);
			this.demoRSA.Name = "demoRSA";
			this.demoRSA.Size = new System.Drawing.Size(568, 163);
			this.demoRSA.TabIndex = 22;
			this.demoRSA.Text = resources.GetString("demoRSA.Text");
			this.demoRSA.TextChanged += new System.EventHandler(this.demoRSA_TextChanged);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.Gold;
			this.button4.Location = new System.Drawing.Point(586, 372);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(153, 33);
			this.button4.TabIndex = 21;
			this.button4.Text = "Generate RSA";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.Lime;
			this.label12.Location = new System.Drawing.Point(745, 377);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(250, 22);
			this.label12.TabIndex = 19;
			this.label12.Text = "AES KEY ENCRYPTED BY RSA";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.Gold;
			this.label11.Location = new System.Drawing.Point(16, 347);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 22);
			this.label11.TabIndex = 18;
			this.label11.Text = "RSA Key";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Orchid;
			this.label10.Location = new System.Drawing.Point(25, 212);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(140, 22);
			this.label10.TabIndex = 16;
			this.label10.Text = "Hexa Hash Key";
			// 
			// demoHashKey
			// 
			this.demoHashKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoHashKey.ForeColor = System.Drawing.Color.Orchid;
			this.demoHashKey.Location = new System.Drawing.Point(176, 209);
			this.demoHashKey.Name = "demoHashKey";
			this.demoHashKey.Size = new System.Drawing.Size(1081, 29);
			this.demoHashKey.TabIndex = 15;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.Orchid;
			this.label9.Location = new System.Drawing.Point(35, 177);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(130, 22);
			this.label9.TabIndex = 14;
			this.label9.Text = "Hexa AES Key";
			// 
			// demoHexaKey
			// 
			this.demoHexaKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoHexaKey.ForeColor = System.Drawing.Color.Orchid;
			this.demoHexaKey.Location = new System.Drawing.Point(176, 174);
			this.demoHexaKey.Name = "demoHexaKey";
			this.demoHexaKey.Size = new System.Drawing.Size(1081, 29);
			this.demoHexaKey.TabIndex = 13;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Orchid;
			this.label8.Location = new System.Drawing.Point(85, 138);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 22);
			this.label8.TabIndex = 12;
			this.label8.Text = "AES Key";
			// 
			// demoKey
			// 
			this.demoKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoKey.ForeColor = System.Drawing.Color.Orchid;
			this.demoKey.Location = new System.Drawing.Point(176, 135);
			this.demoKey.Name = "demoKey";
			this.demoKey.Size = new System.Drawing.Size(1081, 29);
			this.demoKey.TabIndex = 11;
			this.demoKey.Text = "this is a key";
			this.demoKey.TextChanged += new System.EventHandler(this.demoTxt_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(86, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 22);
			this.label7.TabIndex = 10;
			this.label7.Text = "Text";
			// 
			// demoTxt
			// 
			this.demoTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoTxt.ForeColor = System.Drawing.Color.White;
			this.demoTxt.Location = new System.Drawing.Point(176, 21);
			this.demoTxt.Name = "demoTxt";
			this.demoTxt.Size = new System.Drawing.Size(1081, 29);
			this.demoTxt.TabIndex = 9;
			this.demoTxt.TextChanged += new System.EventHandler(this.demoTxt_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Lime;
			this.label6.Location = new System.Drawing.Point(16, 300);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(190, 22);
			this.label6.TabIndex = 8;
			this.label6.Text = "AES Encrypted Text";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.Pink;
			this.button2.Location = new System.Drawing.Point(1121, 241);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(121, 33);
			this.button2.TabIndex = 6;
			this.button2.Text = "Change IV";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Pink;
			this.label5.Location = new System.Drawing.Point(45, 246);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 22);
			this.label5.TabIndex = 5;
			this.label5.Text = "Init Vector";
			// 
			// demoIV
			// 
			this.demoIV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoIV.ForeColor = System.Drawing.Color.Pink;
			this.demoIV.Location = new System.Drawing.Point(176, 243);
			this.demoIV.Name = "demoIV";
			this.demoIV.Size = new System.Drawing.Size(926, 29);
			this.demoIV.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(36, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 22);
			this.label3.TabIndex = 1;
			this.label3.Text = "Hexa Text";
			// 
			// demoHexaTxt
			// 
			this.demoHexaTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.demoHexaTxt.ForeColor = System.Drawing.Color.White;
			this.demoHexaTxt.Location = new System.Drawing.Point(176, 56);
			this.demoHexaTxt.Name = "demoHexaTxt";
			this.demoHexaTxt.Size = new System.Drawing.Size(1081, 29);
			this.demoHexaTxt.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.ClientSize = new System.Drawing.Size(1269, 718);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.panel2Auth);
			this.Controls.Add(this.panel1Register);
			this.Font = new System.Drawing.Font("Consolas", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "PasswordManager";
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.panel1Register.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2Auth.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private RichTextBox key_phrase_txt;
		private Button LoadData;
		private RichTextBox data_txt;
		private Button SaveData;
		private CheckBox checkBox1;
		private Button button1;
		private Panel MainPanel;
		private Panel panel1Register;
		private Button CreatePasse;
		private TextBox pass2Tb;
		private Label label1;
		private TextBox pass1Tb;
		private Panel panel2Auth;
		private Button button3;
		private Label label2;
		private TextBox passAuthTb;
		private Label label3ErrPass;
		private Label label3PasswordStrong;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Panel panel1;
		private GroupBox groupBox3;
		private Label label7;
		private TextBox demoTxt;
		private Label label6;
		private Button button2;
		private Label label5;
		private TextBox demoIV;
		private Label label3;
		private TextBox demoHexaTxt;
		private Label label9;
		private TextBox demoHexaKey;
		private Label label8;
		private TextBox demoKey;
		private Label label10;
		private TextBox demoHashKey;
		private Label label11;
		private Button button4;
		private Label label12;
		private RichTextBox demoRSA;
		private RichTextBox demoAesKeyRsa;
		private RichTextBox demoEncrypted;
		private TextBox decryptedText;
		private Label label4;
	}
}