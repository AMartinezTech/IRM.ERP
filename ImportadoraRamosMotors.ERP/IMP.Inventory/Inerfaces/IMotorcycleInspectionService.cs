using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Core.Inventory.Inerfaces;

public interface IMotorcycleInspectionService
{
    void Inspect(MotorcycleUnitEntity unit);
}
