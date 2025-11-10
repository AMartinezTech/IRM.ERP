namespace IRM.Application.Inventory.Items.MotorcycleBrand;

public class MotorcycleBrandDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string IsActiveName => IsActive ? "Si" : "No";

}
