namespace IRM.WinForm.Inventory.MotorcycleBrand
{
    partial class FrmMotorcycleBrandView
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
            DataGridView = new DataGridView();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            BtnClear = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            CBIsActive = new CheckBox();
            TxtName = new TextBox();
            PanelBottomTitle = new Panel();
            LabelTitle = new Label();
            PanelTopLine = new Panel();
            PanelBottomLine = new Panel();
            errorProvider1 = new ErrorProvider(components);
            LblLoadingData = new Label();
            BtnModel = new FontAwesome.Sharp.IconButton();
            PanelAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelBottomTitle.SuspendLayout();
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
            PanelAlerts.TabIndex = 17;
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
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(270, 72);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(321, 159);
            DataGridView.TabIndex = 16;
            DataGridView.Visible = false;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // BtnPersistence
            // 
            BtnPersistence.Cursor = Cursors.Hand;
            BtnPersistence.IconChar = FontAwesome.Sharp.IconChar.Save;
            BtnPersistence.IconColor = Color.Black;
            BtnPersistence.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnPersistence.Location = new Point(157, 146);
            BtnPersistence.Name = "BtnPersistence";
            BtnPersistence.Size = new Size(85, 85);
            BtnPersistence.TabIndex = 15;
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
            BtnClear.Location = new Point(12, 146);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(85, 85);
            BtnClear.TabIndex = 14;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 55);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 13;
            label1.Text = "Nombre";
            // 
            // CBIsActive
            // 
            CBIsActive.AutoSize = true;
            CBIsActive.Location = new Point(182, 98);
            CBIsActive.Name = "CBIsActive";
            CBIsActive.Size = new Size(60, 19);
            CBIsActive.TabIndex = 12;
            CBIsActive.Text = "Activo";
            CBIsActive.UseVisualStyleBackColor = true;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(12, 69);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(230, 23);
            TxtName.TabIndex = 11;
            TxtName.TextChanged += TxtName_TextChanged;
            // 
            // PanelBottomTitle
            // 
            PanelBottomTitle.Controls.Add(LabelTitle);
            PanelBottomTitle.Dock = DockStyle.Bottom;
            PanelBottomTitle.Location = new Point(0, 261);
            PanelBottomTitle.Name = "PanelBottomTitle";
            PanelBottomTitle.Size = new Size(603, 50);
            PanelBottomTitle.TabIndex = 19;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            LabelTitle.Location = new Point(12, 13);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(158, 25);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de marca";
            // 
            // PanelTopLine
            // 
            PanelTopLine.Location = new Point(0, 31);
            PanelTopLine.Name = "PanelTopLine";
            PanelTopLine.Size = new Size(603, 2);
            PanelTopLine.TabIndex = 18;
            // 
            // PanelBottomLine
            // 
            PanelBottomLine.Location = new Point(0, 259);
            PanelBottomLine.Name = "PanelBottomLine";
            PanelBottomLine.Size = new Size(603, 2);
            PanelBottomLine.TabIndex = 20;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LblLoadingData
            // 
            LblLoadingData.AutoSize = true;
            LblLoadingData.Location = new Point(375, 146);
            LblLoadingData.Name = "LblLoadingData";
            LblLoadingData.Size = new Size(100, 15);
            LblLoadingData.TabIndex = 21;
            LblLoadingData.Text = "Cargando datos...";
            // 
            // BtnModel
            // 
            BtnModel.Cursor = Cursors.Hand;
            BtnModel.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnModel.IconColor = Color.Black;
            BtnModel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnModel.IconSize = 20;
            BtnModel.Location = new Point(270, 36);
            BtnModel.Name = "BtnModel";
            BtnModel.Size = new Size(130, 30);
            BtnModel.TabIndex = 22;
            BtnModel.Text = "&Crear modelo";
            BtnModel.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnModel.UseVisualStyleBackColor = true;
            BtnModel.Visible = false;
            BtnModel.Click += BtnModel_Click;
            // 
            // FrmMotorcycleBrandView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 311);
            Controls.Add(BtnModel);
            Controls.Add(LblLoadingData);
            Controls.Add(PanelAlerts);
            Controls.Add(DataGridView);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(label1);
            Controls.Add(CBIsActive);
            Controls.Add(TxtName);
            Controls.Add(PanelBottomTitle);
            Controls.Add(PanelTopLine);
            Controls.Add(PanelBottomLine);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMotorcycleBrandView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maestro de marca";
            Load += FrmMotorcycleBrandView_Load;
            PanelAlerts.ResumeLayout(false);
            PanelAlerts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            PanelBottomTitle.ResumeLayout(false);
            PanelBottomTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelAlerts;
        private Label LabelAlertMessage;
        private DataGridView DataGridView;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private FontAwesome.Sharp.IconButton BtnClear;
        private Label label1;
        private CheckBox CBIsActive;
        private TextBox TxtName;
        private Panel PanelBottomTitle;
        private Label LabelTitle;
        private Panel PanelTopLine;
        private Panel PanelBottomLine;
        private ErrorProvider errorProvider1;
        private Label LblLoadingData;
        private FontAwesome.Sharp.IconButton BtnModel;
    }
}