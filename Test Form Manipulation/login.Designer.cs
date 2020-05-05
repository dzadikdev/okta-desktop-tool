namespace Test_Form_Manipulation
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.loginpanel = new System.Windows.Forms.Panel();
            this.username1 = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.password1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mfalist = new System.Windows.Forms.ComboBox();
            this.mfapanel = new System.Windows.Forms.Panel();
            this.smspanel = new System.Windows.Forms.Panel();
            this.smsError = new System.Windows.Forms.Label();
            this.submitSMS = new System.Windows.Forms.Button();
            this.smsTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginpanel.SuspendLayout();
            this.mfapanel.SuspendLayout();
            this.smspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginpanel
            // 
            this.loginpanel.Controls.Add(this.username1);
            this.loginpanel.Controls.Add(this.buttonLogin);
            this.loginpanel.Controls.Add(this.label1);
            this.loginpanel.Controls.Add(this.password1);
            this.loginpanel.Controls.Add(this.label2);
            this.loginpanel.Location = new System.Drawing.Point(38, 12);
            this.loginpanel.Name = "loginpanel";
            this.loginpanel.Size = new System.Drawing.Size(396, 278);
            this.loginpanel.TabIndex = 5;
            // 
            // username1
            // 
            this.username1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username1.Location = new System.Drawing.Point(59, 67);
            this.username1.Margin = new System.Windows.Forms.Padding(4);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(271, 26);
            this.username1.TabIndex = 6;
            // 
            // buttonLogin
            // 
            this.buttonLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(230, 189);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 28);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Okta Username";
            // 
            // password1
            // 
            this.password1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1.Location = new System.Drawing.Point(59, 143);
            this.password1.Margin = new System.Windows.Forms.Padding(4);
            this.password1.Name = "password1";
            this.password1.PasswordChar = '*';
            this.password1.Size = new System.Drawing.Size(271, 26);
            this.password1.TabIndex = 7;
            this.password1.UseSystemPasswordChar = true;
            this.password1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Okta Password";
            // 
            // mfalist
            // 
            this.mfalist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mfalist.FormattingEnabled = true;
            this.mfalist.Location = new System.Drawing.Point(282, 22);
            this.mfalist.Name = "mfalist";
            this.mfalist.Size = new System.Drawing.Size(149, 28);
            this.mfalist.TabIndex = 0;
            this.mfalist.SelectedIndexChanged += new System.EventHandler(this.mfalist_SelectedIndexChanged);
            // 
            // mfapanel
            // 
            this.mfapanel.Controls.Add(this.smspanel);
            this.mfapanel.Controls.Add(this.label3);
            this.mfapanel.Controls.Add(this.mfalist);
            this.mfapanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mfapanel.Location = new System.Drawing.Point(0, 0);
            this.mfapanel.Name = "mfapanel";
            this.mfapanel.Size = new System.Drawing.Size(466, 315);
            this.mfapanel.TabIndex = 6;
            this.mfapanel.Visible = false;
            // 
            // smspanel
            // 
            this.smspanel.Controls.Add(this.smsError);
            this.smspanel.Controls.Add(this.submitSMS);
            this.smspanel.Controls.Add(this.smsTextbox);
            this.smspanel.Controls.Add(this.label4);
            this.smspanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.smspanel.Location = new System.Drawing.Point(88, 97);
            this.smspanel.Name = "smspanel";
            this.smspanel.Size = new System.Drawing.Size(307, 176);
            this.smspanel.TabIndex = 15;
            // 
            // smsError
            // 
            this.smsError.AutoSize = true;
            this.smsError.Location = new System.Drawing.Point(48, 136);
            this.smsError.Name = "smsError";
            this.smsError.Size = new System.Drawing.Size(232, 16);
            this.smsError.TabIndex = 18;
            this.smsError.Text = "Code was incorrrect. Please try again.";
            this.smsError.Visible = false;
            // 
            // submitSMS
            // 
            this.submitSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitSMS.Location = new System.Drawing.Point(64, 91);
            this.submitSMS.Name = "submitSMS";
            this.submitSMS.Size = new System.Drawing.Size(178, 32);
            this.submitSMS.TabIndex = 17;
            this.submitSMS.Text = "Validate";
            this.submitSMS.UseVisualStyleBackColor = true;
            this.submitSMS.Click += new System.EventHandler(this.submitSMS_Click);
            // 
            // smsTextbox
            // 
            this.smsTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsTextbox.Location = new System.Drawing.Point(64, 57);
            this.smsTextbox.Name = "smsTextbox";
            this.smsTextbox.Size = new System.Drawing.Size(178, 26);
            this.smsTextbox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Put In SMS Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select MFA Factor";
            // 
            // login
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(466, 315);
            this.Controls.Add(this.mfapanel);
            this.Controls.Add(this.loginpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okta Login";
            this.loginpanel.ResumeLayout(false);
            this.loginpanel.PerformLayout();
            this.mfapanel.ResumeLayout(false);
            this.mfapanel.PerformLayout();
            this.smspanel.ResumeLayout(false);
            this.smspanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel loginpanel;
        private System.Windows.Forms.TextBox username1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password1;
        private System.Windows.Forms.ComboBox mfalist;
        private System.Windows.Forms.Panel mfapanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel smspanel;
        private System.Windows.Forms.Button submitSMS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox smsTextbox;
        private System.Windows.Forms.Label smsError;
    }
}