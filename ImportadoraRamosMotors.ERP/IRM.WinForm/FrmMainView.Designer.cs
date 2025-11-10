namespace IRM.WinForm
{
    partial class FrmMainView
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
            PanelMainMenu = new Panel();
            BtnOrganization = new FontAwesome.Sharp.IconButton();
            BtnPurcharsing = new FontAwesome.Sharp.IconButton();
            BtnInventory = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            PanelTopLine = new Panel();
            PanelLeftMenu = new Panel();
            PanelButtomMenu = new Panel();
            LabelWelcome = new Label();
            PanelButtomLine = new Panel();
            PanelContainer = new Panel();
            PanelMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelButtomMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMainMenu
            // 
            PanelMainMenu.Controls.Add(BtnOrganization);
            PanelMainMenu.Controls.Add(BtnPurcharsing);
            PanelMainMenu.Controls.Add(BtnInventory);
            PanelMainMenu.Controls.Add(pictureBox1);
            PanelMainMenu.Dock = DockStyle.Top;
            PanelMainMenu.Location = new Point(0, 0);
            PanelMainMenu.Name = "PanelMainMenu";
            PanelMainMenu.Size = new Size(1184, 100);
            PanelMainMenu.TabIndex = 0;
            // 
            // BtnOrganization
            // 
            BtnOrganization.Cursor = Cursors.Hand;
            BtnOrganization.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            BtnOrganization.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            BtnOrganization.IconColor = Color.Black;
            BtnOrganization.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnOrganization.Location = new Point(440, 9);
            BtnOrganization.Name = "BtnOrganization";
            BtnOrganization.Size = new Size(85, 85);
            BtnOrganization.TabIndex = 3;
            BtnOrganization.Text = "CONFIG.";
            BtnOrganization.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOrganization.UseVisualStyleBackColor = true;
            // 
            // BtnPurcharsing
            // 
            BtnPurcharsing.Cursor = Cursors.Hand;
            BtnPurcharsing.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            BtnPurcharsing.IconChar = FontAwesome.Sharp.IconChar.TruckFront;
            BtnPurcharsing.IconColor = Color.Black;
            BtnPurcharsing.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPurcharsing.Location = new Point(349, 8);
            BtnPurcharsing.Name = "BtnPurcharsing";
            BtnPurcharsing.Size = new Size(85, 85);
            BtnPurcharsing.TabIndex = 2;
            BtnPurcharsing.Text = "COMPRAS";
            BtnPurcharsing.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPurcharsing.UseVisualStyleBackColor = true;
            // 
            // BtnInventory
            // 
            BtnInventory.Cursor = Cursors.Hand;
            BtnInventory.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            BtnInventory.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnInventory.IconColor = Color.Black;
            BtnInventory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInventory.Location = new Point(258, 8);
            BtnInventory.Name = "BtnInventory";
            BtnInventory.Size = new Size(85, 85);
            BtnInventory.TabIndex = 1;
            BtnInventory.Text = "INVENTARIO";
            BtnInventory.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnInventory.UseVisualStyleBackColor = true;
            BtnInventory.Click += BtnInventory_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.IRMLogo;
            pictureBox1.Location = new Point(12, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PanelTopLine
            // 
            PanelTopLine.Dock = DockStyle.Top;
            PanelTopLine.Location = new Point(0, 100);
            PanelTopLine.Name = "PanelTopLine";
            PanelTopLine.Size = new Size(1184, 2);
            PanelTopLine.TabIndex = 1;
            // 
            // PanelLeftMenu
            // 
            PanelLeftMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PanelLeftMenu.Location = new Point(0, 108);
            PanelLeftMenu.Name = "PanelLeftMenu";
            PanelLeftMenu.Size = new Size(200, 615);
            PanelLeftMenu.TabIndex = 2;
            // 
            // PanelButtomMenu
            // 
            PanelButtomMenu.Controls.Add(LabelWelcome);
            PanelButtomMenu.Dock = DockStyle.Bottom;
            PanelButtomMenu.Location = new Point(0, 731);
            PanelButtomMenu.Name = "PanelButtomMenu";
            PanelButtomMenu.Size = new Size(1184, 30);
            PanelButtomMenu.TabIndex = 3;
            // 
            // LabelWelcome
            // 
            LabelWelcome.AutoSize = true;
            LabelWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            LabelWelcome.Location = new Point(12, 5);
            LabelWelcome.Name = "LabelWelcome";
            LabelWelcome.Size = new Size(244, 20);
            LabelWelcome.TabIndex = 0;
            LabelWelcome.Text = "Bienvenido (nombre de usuario y rol)";
            // 
            // PanelButtomLine
            // 
            PanelButtomLine.Dock = DockStyle.Bottom;
            PanelButtomLine.Location = new Point(0, 729);
            PanelButtomLine.Name = "PanelButtomLine";
            PanelButtomLine.Size = new Size(1184, 2);
            PanelButtomLine.TabIndex = 4;
            // 
            // PanelContainer
            // 
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Location = new Point(206, 108);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(966, 615);
            PanelContainer.TabIndex = 5;
            // 
            // FrmMainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(PanelContainer);
            Controls.Add(PanelButtomLine);
            Controls.Add(PanelButtomMenu);
            Controls.Add(PanelLeftMenu);
            Controls.Add(PanelTopLine);
            Controls.Add(PanelMainMenu);
            Name = "FrmMainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Importadora Ramos Motors S.R.L. ©2025";
            WindowState = FormWindowState.Maximized;
            Load += FrmMainView_Load;
            PanelMainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelButtomMenu.ResumeLayout(false);
            PanelButtomMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMainMenu;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton BtnInventory;
        private Panel PanelTopLine;
        private FontAwesome.Sharp.IconButton BtnPurcharsing;
        private Panel PanelLeftMenu;
        private Panel PanelButtomMenu;
        private Panel PanelButtomLine;
        private Label LabelWelcome;
        private Panel PanelContainer;
        private FontAwesome.Sharp.IconButton BtnOrganization;
    }
}