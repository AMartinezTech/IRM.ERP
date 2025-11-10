namespace IRM.WinForm.Inventory
{
    partial class FrmInventoryLeftMenuView
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
            BtnBrand = new FontAwesome.Sharp.IconButton();
            BtnTraslateOrder = new FontAwesome.Sharp.IconButton();
            BtnColor = new FontAwesome.Sharp.IconButton();
            BtnItem = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // BtnBrand
            // 
            BtnBrand.Cursor = Cursors.Hand;
            BtnBrand.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnBrand.IconColor = Color.Black;
            BtnBrand.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnBrand.IconSize = 25;
            BtnBrand.Location = new Point(12, 64);
            BtnBrand.Name = "BtnBrand";
            BtnBrand.Size = new Size(165, 46);
            BtnBrand.TabIndex = 1;
            BtnBrand.Text = "Maestro de marca";
            BtnBrand.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnBrand.UseVisualStyleBackColor = true;
            BtnBrand.Click += BtnBrand_Click;
            // 
            // BtnTraslateOrder
            // 
            BtnTraslateOrder.Cursor = Cursors.Hand;
            BtnTraslateOrder.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnTraslateOrder.IconColor = Color.Black;
            BtnTraslateOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnTraslateOrder.IconSize = 25;
            BtnTraslateOrder.Location = new Point(12, 168);
            BtnTraslateOrder.Name = "BtnTraslateOrder";
            BtnTraslateOrder.Size = new Size(165, 46);
            BtnTraslateOrder.TabIndex = 3;
            BtnTraslateOrder.Text = "Orden de traslado";
            BtnTraslateOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnTraslateOrder.UseVisualStyleBackColor = true;
            // 
            // BtnColor
            // 
            BtnColor.Cursor = Cursors.Hand;
            BtnColor.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnColor.IconColor = Color.Black;
            BtnColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnColor.IconSize = 25;
            BtnColor.Location = new Point(12, 12);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(165, 46);
            BtnColor.TabIndex = 0;
            BtnColor.Text = "Maestro de color";
            BtnColor.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnColor.UseVisualStyleBackColor = true;
            BtnColor.Click += BtnColor_Click;
            // 
            // BtnItem
            // 
            BtnItem.Cursor = Cursors.Hand;
            BtnItem.IconChar = FontAwesome.Sharp.IconChar.Motorcycle;
            BtnItem.IconColor = Color.Black;
            BtnItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnItem.IconSize = 25;
            BtnItem.Location = new Point(12, 116);
            BtnItem.Name = "BtnItem";
            BtnItem.Size = new Size(165, 46);
            BtnItem.TabIndex = 2;
            BtnItem.Text = "Maestro de Artículo";
            BtnItem.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnItem.UseVisualStyleBackColor = true;
            BtnItem.Click += BtnItem_Click;
            // 
            // FrmInventoryLeftMenuView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 476);
            Controls.Add(BtnItem);
            Controls.Add(BtnColor);
            Controls.Add(BtnTraslateOrder);
            Controls.Add(BtnBrand);
            Name = "FrmInventoryLeftMenuView";
            Text = "FrmInventoryLeftMenuView";
            Load += FrmInventoryLeftMenuView_Load;
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton BtnBrand;
        private FontAwesome.Sharp.IconButton BtnTraslateOrder;
        private FontAwesome.Sharp.IconButton BtnColor;
        private FontAwesome.Sharp.IconButton BtnItem;
    }
}