using IRM.WinForm.Properties;


namespace IRM.WinForm.Utils.DataGrid;


public static class CustomDataGridView
{
    public static void SetCustomDesign(this DataGridView datagrid, CustomDataGridViewParams paramsSetting)
    {
        datagrid.AllowUserToAddRows = false;
        datagrid.AllowUserToDeleteRows = false;
        datagrid.AllowUserToResizeColumns = true;
        datagrid.AllowUserToResizeRows = false;
        datagrid.AllowUserToOrderColumns = false;
        datagrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        datagrid.MultiSelect = false;
        datagrid.RowHeadersVisible = false;
        datagrid.ReadOnly = true;
        datagrid.BackgroundColor = AppColors.Surface;
        datagrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = AppColors.Primary,
            SelectionBackColor = AppColors.Primary,
            ForeColor = AppColors.OnPrimary
        };
        datagrid.DefaultCellStyle = new DataGridViewCellStyle
        {
            SelectionBackColor = AppColors.SurfaceVariant,
            SelectionForeColor = AppColors.OnSurface,
        };
        datagrid.ColumnHeadersHeight = 30;
        datagrid.EnableHeadersVisualStyles = false;
        datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

        // Agregar columnas según sea necesario
        if (paramsSetting.EditColumnView)
        {
            var btnEditColumn = new DataGridViewImageColumn();
            using (var ms = new MemoryStream(Resources.edit))
            {
                Image resizedImage = new Bitmap(Image.FromStream(ms), new Size(18, 18));
                btnEditColumn.Image = resizedImage;
            }


            btnEditColumn.Name = "editCol";
            btnEditColumn.HeaderText = paramsSetting.EditColumnName;
            btnEditColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns.Add(btnEditColumn);
        }

        if (paramsSetting.DeleteColumnView)
        {
            var btnDeleteColumn = new DataGridViewImageColumn();
            using (var ms = new MemoryStream(Resources.delete))
            {
                Image resizedImage = new Bitmap(Image.FromStream(ms), new Size(18, 18));
                btnDeleteColumn.Image = resizedImage;
            }
            btnDeleteColumn.Name = "deleteCol";
            btnDeleteColumn.HeaderText = paramsSetting.DeleteColumnName;
            btnDeleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns.Add(btnDeleteColumn);
        }

        if (paramsSetting.SettingColumnView)
        {
            var btnThirdCol = new DataGridViewImageColumn();
            using (var ms = new MemoryStream(Resources.setting))
            {
                Image resizedImage = new Bitmap(Image.FromStream(ms), new Size(18, 18));
                btnThirdCol.Image = resizedImage;
            }
            btnThirdCol.Name = "settingCol";
            btnThirdCol.HeaderText = paramsSetting.SettingColumnName;
            btnThirdCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns.Add(btnThirdCol);
        }

        if (paramsSetting.PrintColumnView)
        {
            var btnPrintCol = new DataGridViewImageColumn();
            using (var ms = new MemoryStream(Resources.print))
            {
                Image resizedImage = new Bitmap(Image.FromStream(ms), new Size(18, 18));
                btnPrintCol.Image = resizedImage;
            }
            btnPrintCol.Name = "printCol";
            btnPrintCol.HeaderText = paramsSetting.PrintColumnName;
            btnPrintCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns.Add(btnPrintCol);
        }
        if (paramsSetting.PhoneColumnView)
        {
            var btnPrintCol = new DataGridViewImageColumn();
            using (var ms = new MemoryStream(Resources.phone))
            {
                Image resizedImage = new Bitmap(Image.FromStream(ms), new Size(18, 18));
                btnPrintCol.Image = resizedImage;
            }
            btnPrintCol.Name = "phoneCol";
            btnPrintCol.HeaderText = paramsSetting.PhoneColumnName;
            btnPrintCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns.Add(btnPrintCol);
        }
        // Suscribir evento después de agregar las columnas
        datagrid.CellMouseEnter += (sender, e) =>
        {
            bool cursorChanged = false;

            if (paramsSetting.EditColumnView && datagrid.Columns.Contains("editCol") && e.ColumnIndex == datagrid.Columns["editCol"]!.Index && e.RowIndex >= 0)
            {
                datagrid.Cursor = Cursors.Hand;
                cursorChanged = true;
            }
            if (paramsSetting.DeleteColumnView && datagrid.Columns.Contains("deleteCol") && e.ColumnIndex == datagrid.Columns["deleteCol"]!.Index && e.RowIndex >= 0)
            {
                datagrid.Cursor = Cursors.Hand;
                cursorChanged = true;
            }
            if (paramsSetting.SettingColumnView && datagrid.Columns.Contains("settingCol") && e.ColumnIndex == datagrid.Columns["settingCol"]!.Index && e.RowIndex >= 0)
            {
                datagrid.Cursor = Cursors.Hand;
                cursorChanged = true;
            }
            if (paramsSetting.PrintColumnView && datagrid.Columns.Contains("printCol") && e.ColumnIndex == datagrid.Columns["printCol"]!.Index && e.RowIndex >= 0)
            {
                datagrid.Cursor = Cursors.Hand;
                cursorChanged = true;
            }
            if (paramsSetting.PhoneColumnView && datagrid.Columns.Contains("phoneCol") && e.ColumnIndex == datagrid.Columns["phoneCol"]!.Index && e.RowIndex >= 0)
            {
                datagrid.Cursor = Cursors.Hand;
                cursorChanged = true;
            }

            // Si el cursor no ha cambiado, establecer el cursor por defecto
            if (!cursorChanged)
            {
                datagrid.Cursor = Cursors.Default;
            }
        };
    }
}

public class CustomDataGridViewParams
{
    public bool EditColumnView { get; set; } = false;
    public bool DeleteColumnView { get; set; } = false;
    public bool SettingColumnView { get; set; } = false;
    public bool PrintColumnView { get; set; } = false;
    public bool PhoneColumnView { get; set; } = false;

    public string EditColumnName { get; set; } = "EDITAR";
    public string DeleteColumnName { get; set; } = "BORRAR";
    public string SettingColumnName { get; set; } = "CONFIG.";
    public string PrintColumnName { get; set; } = "PRINT";
    public string PhoneColumnName { get; set; } = "CALL";



}