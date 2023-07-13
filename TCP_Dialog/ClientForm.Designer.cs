namespace TCP_Dialog {
	partial class ClientForm {
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
			this.RegisterBT = new System.Windows.Forms.Button();
			this.nickTB = new System.Windows.Forms.TextBox();
			this.output_field = new System.Windows.Forms.RichTextBox();
			this.send_BT = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label_online = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// RegisterBT
			// 
			this.RegisterBT.Enabled = false;
			this.RegisterBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RegisterBT.Location = new System.Drawing.Point(12, 41);
			this.RegisterBT.Name = "RegisterBT";
			this.RegisterBT.Size = new System.Drawing.Size(377, 30);
			this.RegisterBT.TabIndex = 1;
			this.RegisterBT.Text = "S\'identifier";
			this.RegisterBT.UseVisualStyleBackColor = true;
			this.RegisterBT.Click += new System.EventHandler(this.RegisterClick);
			// 
			// nickTB
			// 
			this.nickTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
			this.nickTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nickTB.ForeColor = System.Drawing.Color.Lime;
			this.nickTB.Location = new System.Drawing.Point(98, 11);
			this.nickTB.Name = "nickTB";
			this.nickTB.Size = new System.Drawing.Size(291, 24);
			this.nickTB.TabIndex = 2;
			this.nickTB.TextChanged += new System.EventHandler(this.nickTB_TextChanged);
			// 
			// output_field
			// 
			this.output_field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
			this.output_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.output_field.Dock = System.Windows.Forms.DockStyle.Fill;
			this.output_field.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.output_field.ForeColor = System.Drawing.Color.White;
			this.output_field.Location = new System.Drawing.Point(0, 86);
			this.output_field.Name = "output_field";
			this.output_field.ReadOnly = true;
			this.output_field.Size = new System.Drawing.Size(968, 471);
			this.output_field.TabIndex = 1;
			this.output_field.Text = "";
			// 
			// send_BT
			// 
			this.send_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.send_BT.Enabled = false;
			this.send_BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.send_BT.ForeColor = System.Drawing.Color.MediumAquamarine;
			this.send_BT.Location = new System.Drawing.Point(707, 11);
			this.send_BT.Name = "send_BT";
			this.send_BT.Size = new System.Drawing.Size(250, 30);
			this.send_BT.TabIndex = 6;
			this.send_BT.Text = "Composer un message";
			this.send_BT.UseVisualStyleBackColor = true;
			this.send_BT.Click += new System.EventHandler(this.RedactClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Indicatif";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(707, 51);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(250, 20);
			this.progressBar1.TabIndex = 8;
			this.progressBar1.Visible = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Magenta;
			this.label2.Location = new System.Drawing.Point(541, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Réception fichier :";
			this.label2.Visible = false;
			// 
			// label_online
			// 
			this.label_online.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_online.AutoSize = true;
			this.label_online.ForeColor = System.Drawing.Color.MediumAquamarine;
			this.label_online.Location = new System.Drawing.Point(413, 13);
			this.label_online.Name = "label_online";
			this.label_online.Size = new System.Drawing.Size(192, 17);
			this.label_online.TabIndex = 10;
			this.label_online.Text = "0 utilisateurs en ligne";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.RegisterBT);
			this.panel1.Controls.Add(this.label_online);
			this.panel1.Controls.Add(this.nickTB);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.send_BT);
			this.panel1.Controls.Add(this.progressBar1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(968, 86);
			this.panel1.TabIndex = 11;
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(950, 513);
			this.Controls.Add(this.output_field);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Consolas", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.Lime;
			this.MinimumSize = new System.Drawing.Size(968, 557);
			this.Name = "ClientForm";
			this.ShowIcon = false;
			this.Text = "MATIS NG";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private Button RegisterBT;
		private TextBox nickTB;
		private RichTextBox output_field;
		private Button send_BT;
		private Label label1;
		private ProgressBar progressBar1;
		private Label label2;
		private Label label_online;
		private Panel panel1;
	}
}