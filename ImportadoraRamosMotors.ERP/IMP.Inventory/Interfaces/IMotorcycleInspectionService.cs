using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Core.Inventory.Interfaces;

public interface IMotorcycleInspectionService
{
    void Inspect(MotorcycleEntity unit);
}
