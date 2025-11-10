namespace IRM.WinForm.Inventory.MotorcycleColor;

internal class MotorcycleColorFormatingDGColumns
{
    internal static void Apply(DataGridView dataGridView)
    {
        //Desable aut generate columns
        dataGridView.AutoGenerateColumns = false;

        // Add columns
        var colId = new DataGridViewTextBoxColumn
        {
            Name = "id",
            HeaderText = "ID",
            DataPropertyName = "id", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            Visible = false

        };
        dataGridView.Columns.Add(colId);
         
        var colName = new DataGridViewTextBoxColumn
        {
            Name = "Name",
            HeaderText = "NOMBRE",
            DataPropertyName = "Name", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(colName);

        var IsActiveName = new DataGridViewTextBoxColumn
        {
            Name = "IsActiveName",
            HeaderText = "ACTIVO",
            DataPropertyName = "IsActiveName", // Vincula con la propiedad del resultado
            Width = 60,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }, 

        };
        dataGridView.Columns.Add(IsActiveName);


    }
}
