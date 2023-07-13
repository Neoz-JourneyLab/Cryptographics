namespace TCP_Dialog {
	partial class RedactForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.inputField = new System.Windows.Forms.RichTextBox();
			this.sendMessage = new System.Windows.Forms.Button();
			this.sendFile = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// inputField
			// 
			this.inputField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.inputField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.inputField.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.inputField.ForeColor = System.Drawing.Color.DarkGray;
			this.inputField.Location = new System.Drawing.Point(0, 75);
			this.inputField.Name = "inputField";
			this.inputField.ReadOnly = true;
			this.inputField.Size = new System.Drawing.Size(1000, 333);
			this.inputField.TabIndex = 0;
			this.inputField.Text = "Message...";
			this.inputField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.inputField_MouseClick);
			this.inputField.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// sendMessage
			// 
			this.sendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sendMessage.Enabled = false;
			this.sendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sendMessage.ForeColor = System.Drawing.Color.White;
			this.sendMessage.Location = new System.Drawing.Point(829, 356);
			this.sendMessage.Name = "sendMessage";
			this.sendMessage.Size = new System.Drawing.Size(159, 40);
			this.sendMessage.TabIndex = 1;
			this.sendMessage.Text = "Envoyer";
			this.sendMessage.UseVisualStyleBackColor = true;
			this.sendMessage.Click += new System.EventHandler(this.button1_Click);
			// 
			// sendFile
			// 
			this.sendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sendFile.Enabled = false;
			this.sendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sendFile.ForeColor = System.Drawing.Color.White;
			this.sendFile.Location = new System.Drawing.Point(779, 9);
			this.sendFile.Name = "sendFile";
			this.sendFile.Size = new System.Drawing.Size(209, 33);
			this.sendFile.TabIndex = 2;
			this.sendFile.Text = "Envoyer un fichier";
			this.sendFile.UseVisualStyleBackColor = true;
			this.sendFile.Click += new System.EventHandler(this.button2_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.comboBox1.DropDownHeight = 500;
			this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboBox1.ForeColor = System.Drawing.Color.Lime;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.IntegralHeight = false;
			this.comboBox1.Location = new System.Drawing.Point(12, 36);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(304, 30);
			this.comboBox1.Sorted = true;
			this.comboBox1.TabIndex = 4;
			this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 22);
			this.label1.TabIndex = 5;
			this.label1.Text = "Destinataire";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(718, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(270, 22);
			this.label2.TabIndex = 6;
			this.label2.Text = "Fichier envoyé avec succès";
			this.label2.Visible = false;
			// 
			// RedactForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(1000, 408);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.sendFile);
			this.Controls.Add(this.sendMessage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.inputField);
			this.Font = new System.Drawing.Font("Consolas", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.Lime;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "RedactForm";
			this.ShowIcon = false;
			this.Text = "Rédiger un message";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RichTextBox inputField;
		private Button sendMessage;
		private Button sendFile;
		private ComboBox comboBox1;
		private Label label1;
		private Label label2;
	}
}