namespace IRM.WinForm.Inventory.Item
{
    partial class FrmMotorcycleColorView
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
            TxtName = new TextBox();
            CBIsActive = new CheckBox();
            label1 = new Label();
            BtnClear = new FontAwesome.Sharp.IconButton();
            BtnPersistence = new FontAwesome.Sharp.IconButton();
            DataGridView = new DataGridView();
            PanelAlerts = new Panel();
            LabelAlertMessage = new Label();
            PanelTopLine = new Panel();
            PanelBottomTitle = new Panel();
            LabelTitle = new Label();
            PanelBottomLine = new Panel();
            errorProvider1 = new ErrorProvider(components);
            LblLoadingData = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            PanelAlerts.SuspendLayout();
            PanelBottomTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // TxtName
            // 
            TxtName.Location = new Point(12, 69);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(230, 23);
            TxtName.TabIndex = 0;
            TxtName.TextChanged += TxtName_TextChanged;
            // 
            // CBIsActive
            // 
            CBIsActive.AutoSize = true;
            CBIsActive.Location = new Point(182, 98);
            CBIsActive.Name = "CBIsActive";
            CBIsActive.Size = new Size(60, 19);
            CBIsActive.TabIndex = 1;
            CBIsActive.Text = "Activo";
            CBIsActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 55);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
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
            BtnClear.TabIndex = 3;
            BtnClear.Text = "&Limpiar";
            BtnClear.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
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
            BtnPersistence.TabIndex = 4;
            BtnPersistence.Text = "&Guardar";
            BtnPersistence.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPersistence.UseVisualStyleBackColor = true;
            BtnPersistence.Click += BtnPersistence_Click;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(265, 72);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(321, 159);
            DataGridView.TabIndex = 5;
            DataGridView.Visible = false;
            DataGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // PanelAlerts
            // 
            PanelAlerts.Controls.Add(LabelAlertMessage);
            PanelAlerts.Dock = DockStyle.Top;
            PanelAlerts.Location = new Point(0, 0);
            PanelAlerts.Name = "PanelAlerts";
            PanelAlerts.Size = new Size(603, 30);
            PanelAlerts.TabIndex = 6;
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
            // PanelTopLine
            // 
            PanelTopLine.Dock = DockStyle.Top;
            PanelTopLine.Location = new Point(0, 30);
            PanelTopLine.Name = "PanelTopLine";
            PanelTopLine.Size = new Size(603, 2);
            PanelTopLine.TabIndex = 7;
            // 
            // PanelBottomTitle
            // 
            PanelBottomTitle.Controls.Add(LabelTitle);
            PanelBottomTitle.Dock = DockStyle.Bottom;
            PanelBottomTitle.Location = new Point(0, 261);
            PanelBottomTitle.Name = "PanelBottomTitle";
            PanelBottomTitle.Size = new Size(603, 50);
            PanelBottomTitle.TabIndex = 8;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            LabelTitle.Location = new Point(12, 13);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(147, 25);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Maestro de color";
            // 
            // PanelBottomLine
            // 
            PanelBottomLine.Dock = DockStyle.Bottom;
            PanelBottomLine.Location = new Point(0, 259);
            PanelBottomLine.Name = "PanelBottomLine";
            PanelBottomLine.Size = new Size(603, 2);
            PanelBottomLine.TabIndex = 9;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LblLoadingData
            // 
            LblLoadingData.AutoSize = true;
            LblLoadingData.Location = new Point(372, 146);
            LblLoadingData.Name = "LblLoadingData";
            LblLoadingData.Size = new Size(100, 15);
            LblLoadingData.TabIndex = 10;
            LblLoadingData.Text = "Cargando datos...";
            // 
            // FrmMotorcycleColorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 311);
            Controls.Add(LblLoadingData);
            Controls.Add(PanelBottomLine);
            Controls.Add(PanelBottomTitle);
            Controls.Add(PanelTopLine);
            Controls.Add(PanelAlerts);
            Controls.Add(DataGridView);
            Controls.Add(BtnPersistence);
            Controls.Add(BtnClear);
            Controls.Add(label1);
            Controls.Add(CBIsActive);
            Controls.Add(TxtName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMotorcycleColorView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maestro de color";
            Load += FrmItemColor_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            PanelAlerts.ResumeLayout(false);
            PanelAlerts.PerformLayout();
            PanelBottomTitle.ResumeLayout(false);
            PanelBottomTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtName;
        private CheckBox CBIsActive;
        private Label label1;
        private FontAwesome.Sharp.IconButton BtnClear;
        private FontAwesome.Sharp.IconButton BtnPersistence;
        private DataGridView DataGridView;
        private Panel PanelAlerts;
        private Panel PanelTopLine;
        private Panel PanelBottomTitle;
        private Panel PanelBottomLine;
        private Label LabelAlertMessage;
        private ErrorProvider errorProvider1;
        private Label LabelTitle;
        private Label LblLoadingData;
    }
}