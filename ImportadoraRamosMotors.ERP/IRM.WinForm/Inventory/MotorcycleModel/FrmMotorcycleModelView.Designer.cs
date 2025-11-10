namespace IRM.WinForm.Inventory.MotorcycleModel
{
    partial class FrmMotorcycleModelView
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
            PanelAlerts = new Panel();
            LabelAlertMessage = new Label();
            PanelBottomTitle = new Panel();
            LabelTitle = new Label();
            PanelTopLine = new Panel();
            PanelBottomLine = new Panel();
            LblLoadingData = new Label();
            DataGridView = new DataGridView();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            CBIsActive = new CheckBox();
            TxtName = new TextBox();
            LblBrandName = new Label();
            errorProvider1 = new ErrorProvider(components);
            PanelAlerts.SuspendLayout();
            PanelBottomTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // PanelAlerts
            // 
            PanelAlerts.Controls.Add(LabelAlertMessage);
            PanelAlerts.Dock = DockStyle.Top;
            PanelAlerts.Location = new Point(0, 0);
            PanelAlerts.Name = "PanelAlerts";
            PanelAlerts.Size = new Size(603, 30);
            PanelAlerts.TabIndex = 18;
            // 
            // LabelAlertMessage
            // 
            LabelAlertMessage.AutoSize = true;
            LabelAlertMessage.Font = new Font("Segoe UI", 11F);
            LabelAlertMessage.Location = new Point(11, 5);
            LabelAlertMessage.Name = "LabelAlertMessage";
            LabelAlertMessage.Size = new Size(50, 20);
            LabelAlertMessage.TabIndex = 0;
            LabelAlertMessage.Text = "label2";
            // 
            // PanelBottomTitle
            // 
            PanelBottomTitle.Controls.Add(LabelTitle);
            PanelBottomTitle.Dock = DockStyle.Bottom;
            PanelBottomTitle.Location = new Point(0, 261);
            PanelBottomTitle.Name = "PanelBottomTitle";
            PanelBottomTitle.Size = new Size(603, 50);
            PanelBottomTitle.TabIndex = 20;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            LabelTitle.Location = new Point(12, 13);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(167, 25);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de modelo";
            // 
            // PanelTopLine
            // 
            PanelTopLine.Dock = DockStyle.Top;
            PanelTopLine.Location = new Point(0, 30);
            PanelTopLine.Name = "PanelTopLine";
            PanelTopLine.Size = new Size(603, 2);
            PanelTopLine.TabIndex = 21;
            // 
            // PanelBottomLine
            // 
            PanelBottomLine.Dock = DockStyle.Bottom;
            PanelBottomLine.Location = new Point(0, 259);
            PanelBottomLine.Name = "PanelBottomLine";
            PanelBottomLine.Size = new Size(603, 2);
            PanelBottomLine.TabIndex = 22;
            // 
            // LblLoadingData
            // 
            LblLoadingData.AutoSize = true;
            LblLoadingData.Location = new Point(375, 148);
            LblLoadingData.Name = "LblLoadingData";
            LblLoadingData.Size = new Size(100, 15);
            LblLoadingData.TabIndex = 29;
            LblLoadingData.Text = "Cargando datos...";
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(270, 74);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(321, 159);
            DataGridView.TabIndex = 28;
            DataGridView.Visible = false;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(157, 148);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 27;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // BtnClear
            // 
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.IconChar = FontAwesome.Sharp.IconChar.File;
            BtnClear.IconColor = Color.Black;
            BtnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClear.Location = new Point(12, 148);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 26;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 57);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 25;
            label1.Text = "Nombre";
            // 
            // CBIsActive
            // 
            CBIsActive.AutoSize = true;
            CBIsActive.Location = new Point(182, 100);
            CBIsActive.Name = "CBIsActive";
            CBIsActive.Size = new Size(60, 19);
            CBIsActive.TabIndex = 24;
            CBIsActive.Text = "Activo";
            CBIsActive.UseVisualStyleBackColor = true;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(12, 71);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(230, 23);
            TxtName.TabIndex = 23;
            TxtName.TextChanged += TxtName_TextChanged;
            // 
            // LblBrandName
            // 
            LblBrandName.AutoSize = true;
            LblBrandName.Font = new Font("Segoe UI", 11F);
            LblBrandName.Location = new Point(270, 46);
            LblBrandName.Name = "LblBrandName";
            LblBrandName.Size = new Size(57, 20);
            LblBrandName.TabIndex = 30;
            LblBrandName.Text = "Marca: ";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmMotorcycleModelView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 311);
            Controls.Add(LblBrandName);
            Controls.Add(LblLoadingData);
            Controls.Add(DataGridView);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(label1);
            Controls.Add(CBIsActive);
            Controls.Add(TxtName);
            Controls.Add(PanelBottomLine);
            Controls.Add(PanelTopLine);
            Controls.Add(PanelBottomTitle);
            Controls.Add(PanelAlerts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMotorcycleModelView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maestro de modelo";
            Load += FrmMotorcycleModelView_Load;
            PanelAlerts.ResumeLayout(false);
            PanelAlerts.PerformLayout();
            PanelBottomTitle.ResumeLayout(false);
            PanelBottomTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelAlerts;
        private Label LabelAlertMessage;
        private Panel PanelBottomTitle;
        private Label LabelTitle;
        private Panel PanelTopLine;
        private Panel PanelBottomLine;
        private Label LblLoadingData;
        private DataGridView DataGridView;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private Label label1;
        private CheckBox CBIsActive;
        private TextBox TxtName;
        private ErrorProvider errorProvider1;
        public Label LblBrandName;
    }
}