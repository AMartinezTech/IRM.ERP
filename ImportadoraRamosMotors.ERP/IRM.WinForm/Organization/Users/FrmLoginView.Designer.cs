namespace IRM.WinForm.Organization.Users
{
    partial class FrmLoginView
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            TextBoxEmail = new TextBox();
            TextBoxPassword = new TextBox();
            label2 = new Label();
            BtnLogin = new FontAwesome.Sharp.IconButton();
            IconPictureBoxLogin = new FontAwesome.Sharp.IconPictureBox();
            PanelAlertMessage = new Panel();
            LabelAlertMessage = new Label();
            PanelLineTop = new Panel();
            PanelButtom = new Panel();
            PanelLineButtom = new Panel();
            errorProvider1 = new ErrorProvider(components);
            LabelCompanyName = new Label();
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxLogin).BeginInit();
            PanelAlertMessage.SuspendLayout();
            PanelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 83);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Location = new Point(12, 101);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(165, 23);
            TextBoxEmail.TabIndex = 1;
            TextBoxEmail.TextChanged += TextBoxEmail_TextChanged;
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Location = new Point(12, 161);
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.Size = new Size(165, 23);
            TextBoxPassword.TabIndex = 3;
            TextBoxPassword.TextChanged += TextBoxPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 143);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Clave";
            // 
            // BtnLogin
            // 
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            BtnLogin.IconColor = Color.Black;
            BtnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnLogin.Location = new Point(12, 266);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(310, 75);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Iniciar sessión";
            BtnLogin.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // IconPictureBoxLogin
            // 
            IconPictureBoxLogin.BackColor = SystemColors.Control;
            IconPictureBoxLogin.ForeColor = SystemColors.ControlText;
            IconPictureBoxLogin.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            IconPictureBoxLogin.IconColor = SystemColors.ControlText;
            IconPictureBoxLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconPictureBoxLogin.IconSize = 134;
            IconPictureBoxLogin.Location = new Point(184, 83);
            IconPictureBoxLogin.Name = "IconPictureBoxLogin";
            IconPictureBoxLogin.Size = new Size(138, 134);
            IconPictureBoxLogin.TabIndex = 5;
            IconPictureBoxLogin.TabStop = false;
            // 
            // PanelAlertMessage
            // 
            PanelAlertMessage.Controls.Add(LabelAlertMessage);
            PanelAlertMessage.Dock = DockStyle.Top;
            PanelAlertMessage.Location = new Point(0, 0);
            PanelAlertMessage.Name = "PanelAlertMessage";
            PanelAlertMessage.Size = new Size(334, 35);
            PanelAlertMessage.TabIndex = 6;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 9.5F);
            LabelAlertMessage.Location = new Point(12, 9);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(43, 17);
            LabelAlertMessage.TabIndex = 0;
            LabelAlertMessage.Text = "label3";
            // 
            // PanelLineTop
            // 
            PanelLineTop.Dock = DockStyle.Top;
            PanelLineTop.Location = new Point(0, 35);
            PanelLineTop.Name = "PanelLineTop";
            PanelLineTop.Size = new Size(334, 2);
            PanelLineTop.TabIndex = 7;
            // 
            // PanelButtom
            // 
            PanelButtom.Controls.Add(LabelCompanyName);
            PanelButtom.Dock = DockStyle.Bottom;
            PanelButtom.Location = new Point(0, 431);
            PanelButtom.Name = "PanelButtom";
            PanelButtom.Size = new Size(334, 30);
            PanelButtom.TabIndex = 8;
            // 
            // PanelLineButtom
            // 
            PanelLineButtom.Dock = DockStyle.Bottom;
            PanelLineButtom.Location = new Point(0, 429);
            PanelLineButtom.Name = "PanelLineButtom";
            PanelLineButtom.Size = new Size(334, 2);
            PanelLineButtom.TabIndex = 9;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LabelCompanyName
            // 
            LabelCompanyName.AutoSize = true;
            LabelCompanyName.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            LabelCompanyName.Location = new Point(12, 5);
            LabelCompanyName.Name = "LabelCompanyName";
            LabelCompanyName.Size = new Size(218, 20);
            LabelCompanyName.TabIndex = 0;
            LabelCompanyName.Text = "Importadora Ramos Motor, S.R.L.";
            // 
            // FrmLoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 461);
            Controls.Add(PanelLineButtom);
            Controls.Add(PanelButtom);
            Controls.Add(PanelLineTop);
            Controls.Add(PanelAlertMessage);
            Controls.Add(IconPictureBoxLogin);
            Controls.Add(BtnLogin);
            Controls.Add(TextBoxPassword);
            Controls.Add(label2);
            Controls.Add(TextBoxEmail);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sessión";
            Load += FrmLoginView_Load;
            ((System.ComponentModel.ISupportInitialize)IconPictureBoxLogin).EndInit();
            PanelAlertMessage.ResumeLayout(false);
            PanelAlertMessage.PerformLayout();
            PanelButtom.ResumeLayout(false);
            PanelButtom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxEmail;
        private TextBox TextBoxPassword;
        private Label label2;
        private FontAwesome.Sharp.IconButton BtnLogin;
        private FontAwesome.Sharp.IconPictureBox IconPictureBoxLogin;
        private Panel PanelAlertMessage;
        private Panel PanelLineTop;
        private Panel PanelButtom;
        private Panel PanelLineButtom;
        private Label LabelAlertMessage;
        private ErrorProvider errorProvider1;
        private Label LabelCompanyName;
    }
}