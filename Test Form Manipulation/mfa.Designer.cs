namespace Test_Form_Manipulation
{
    partial class mfa
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
            this.mfalist = new System.Windows.Forms.ComboBox();
            this.mfapanel = new System.Windows.Forms.Panel();
            this.smspanel = new System.Windows.Forms.Panel();
            this.smssent = new System.Windows.Forms.Label();
            this.smsSend = new System.Windows.Forms.Button();
            this.smsError = new System.Windows.Forms.Label();
            this.submitSMS = new System.Windows.Forms.Button();
            this.smsTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mfapanel.SuspendLayout();
            this.smspanel.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // smspanel
            // 
            this.smspanel.Controls.Add(this.smssent);
            this.smspanel.Controls.Add(this.smsSend);
            this.smspanel.Controls.Add(this.smsError);
            this.smspanel.Controls.Add(this.submitSMS);
            this.smspanel.Controls.Add(this.smsTextbox);
            this.smspanel.Controls.Add(this.label4);
            this.smspanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.smspanel.Location = new System.Drawing.Point(34, 84);
            this.smspanel.Name = "smspanel";
            this.smspanel.Size = new System.Drawing.Size(407, 219);
            this.smspanel.TabIndex = 15;
            this.smspanel.Visible = false;
            // 
            // smssent
            // 
            this.smssent.AutoSize = true;
            this.smssent.Location = new System.Drawing.Point(233, 108);
            this.smssent.Name = "smssent";
            this.smssent.Size = new System.Drawing.Size(64, 16);
            this.smssent.TabIndex = 20;
            this.smssent.Text = "Text Sent";
            this.smssent.Visible = false;
            // 
            // smsSend
            // 
            this.smsSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smsSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsSend.Location = new System.Drawing.Point(210, 73);
            this.smsSend.Name = "smsSend";
            this.smsSend.Size = new System.Drawing.Size(114, 32);
            this.smsSend.TabIndex = 19;
            this.smsSend.Text = "Send Code";
            this.smsSend.UseVisualStyleBackColor = true;
            this.smsSend.Click += new System.EventHandler(this.smsSend_Click);
            // 
            // smsError
            // 
            this.smsError.AutoSize = true;
            this.smsError.Location = new System.Drawing.Point(92, 175);
            this.smsError.Name = "smsError";
            this.smsError.Size = new System.Drawing.Size(232, 16);
            this.smsError.TabIndex = 18;
            this.smsError.Text = "Code was incorrrect. Please try again.";
            this.smsError.Visible = false;
            // 
            // submitSMS
            // 
            this.submitSMS.Enabled = false;
            this.submitSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitSMS.Location = new System.Drawing.Point(108, 140);
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
            this.smsTextbox.Location = new System.Drawing.Point(65, 76);
            this.smsTextbox.Name = "smsTextbox";
            this.smsTextbox.Size = new System.Drawing.Size(139, 26);
            this.smsTextbox.TabIndex = 15;
            this.smsTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.smsTextbox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 22);
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
            // mfa
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(466, 315);
            this.Controls.Add(this.mfapanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mfa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Okta MFA";
            this.Load += new System.EventHandler(this.mfa_Load);
            this.mfapanel.ResumeLayout(false);
            this.mfapanel.PerformLayout();
            this.smspanel.ResumeLayout(false);
            this.smspanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox mfalist;
        private System.Windows.Forms.Panel mfapanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel smspanel;
        private System.Windows.Forms.Button submitSMS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox smsTextbox;
        private System.Windows.Forms.Label smsError;
        private System.Windows.Forms.Button smsSend;
        private System.Windows.Forms.Label smssent;
    }
}