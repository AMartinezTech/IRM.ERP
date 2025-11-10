using IRM.Core.BaseEntities;
using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles.ValueObjets; 
using System.Drawing; 

namespace IRM.Core.Inventory.Items.Motorcycles;

public class MotorcycleEntity : EntityBase
{
    
    public Guid MotorcycleCatalogId { get; private set; }  // Relationship with Motorcycle
    public string ChassisNumber { get; private set; }
    public string EngineNumber { get; private set; }
    public MotorcycleUnitStatusEnum Status { get; private set; } = MotorcycleUnitStatusEnum.PurchaseOrder;
    public MotorcycleLocation? CurrentLocation { get; private set; }
    public bool IsImported { get; private set; }    
    private readonly List<MotorcycleInspectionEntity> _motorcycleInspection = [];
    public IReadOnlyCollection<MotorcycleInspectionEntity> MotorcycleInspection => _motorcycleInspection.AsReadOnly();
    private MotorcycleEntity(Guid motorcycleCatalogId, string chassisNumber, string engineNumber, bool isImported)
    {
        Id = Guid.NewGuid();
        MotorcycleCatalogId = motorcycleCatalogId;
        ChassisNumber = chassisNumber;
        EngineNumber = engineNumber;
        CurrentLocation = MotorcycleLocation.NewMotocicleUnit();
        IsImported = isImported;
    }
    public static MotorcycleEntity Create(Guid motorcycleCatalogId, string chassisNumber, string engineNumber, bool isImported)
    {
        return new MotorcycleEntity(motorcycleCatalogId, chassisNumber, engineNumber, isImported);
    }
    
    // 🚚 Recibida en el almacén principal
    public void ReceiveInMainWarehouse(Guid warehouseId)
    {
        if (Status != MotorcycleUnitStatusEnum.PurchaseOrder)
            throw new ValidationException("Solo las motocicletas en orden de compra pueden ser recibidas en el almacén principal.");

        CurrentLocation = MotorcycleLocation.Warehouse(warehouseId);
        Status = MotorcycleUnitStatusEnum.InWarehouse;
    }

    // 🚛 Enviada a una sucursal
    public void SendToBranch(Guid sourceWarehouseId, Guid targetBranchId)
    {
        if (Status != MotorcycleUnitStatusEnum.InWarehouse)
            throw new ValidationException("Solo las motocicletas en almacén pueden enviarse a una sucursal.");

        CurrentLocation = MotorcycleLocation.InTransit(sourceWarehouseId, targetBranchId);
        Status = MotorcycleUnitStatusEnum.InTransit;
    }

    // 📦 Recibida en la sucursal (confirmación de traslado)
    public void ReceiveInBranch(Guid branchId)
    {
        if (Status != MotorcycleUnitStatusEnum.InTransit)
            throw new ValidationException("Solo las motocicletas en tránsito pueden ser recibidas en una sucursal.");

        CurrentLocation = MotorcycleLocation.Branch(branchId);
        Status = MotorcycleUnitStatusEnum.Inventory;
    }

    // 💰 Vendida desde la sucursal
    public void MarkAsSold()
    {
        if (Status != MotorcycleUnitStatusEnum.Inventory)
            throw new ValidationException("Solo las motocicletas en inventario pueden marcarse como vendidas.");

        CurrentLocation = null;
        Status = MotorcycleUnitStatusEnum.Sold;
    }

    // 🚨 Reportar robo
    public void MarkAsStolen()
    {
        if (Status == MotorcycleUnitStatusEnum.Sold)
            throw new ValidationException("No se puede marcar como robada una motocicleta vendida.");

        Status = MotorcycleUnitStatusEnum.Stolen;
    }

    // 🔧 Marcar como dañada
    public void MarkAsDamaged()
    {
        if (Status == MotorcycleUnitStatusEnum.Sold)
            throw new ValidationException("No se puede marcar como dañada una motocicleta vendida.");

        Status = MotorcycleUnitStatusEnum.Damaged;
    }

    // ⚙️ Marcar como desmantelada
    public void MarkAsDismantled()
    {
        if (Status != MotorcycleUnitStatusEnum.Damaged && Status != MotorcycleUnitStatusEnum.Inventory)
            throw new ValidationException("Solo se puede desmantelar una motocicleta dañada o en inventario.");

        Status = MotorcycleUnitStatusEnum.Dismantled;
        CurrentLocation = null;
    }
    public override void Validate()
    {
        if (MotorcycleCatalogId == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CATALOGO")} - {nameof(MotorcycleCatalogId)}");

        if (string.IsNullOrWhiteSpace(ChassisNumber))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "NÚMERO DE CHASIS")} - {nameof(ChassisNumber)}");

        if (string.IsNullOrWhiteSpace(EngineNumber))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "NÚMERO DE MAQUINA")} - {nameof(Color)}");
       
        if (MotorcycleInspection ==  null)
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "INSPECCIÓN")} - {nameof(MotorcycleInspection)}");

    }
    public void EnsureCanBeDeleted()
    {
        if (_motorcycleInspection.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeDeletedHasMovement, "LA UNIDAD")}");
    }
    public void Update(string chassisNumber, string engineNumber, bool isImported)
    {
        if (_motorcycleInspection.Count != 0)
            throw new ValidationException($"{string.Format(CommonErrors.CannotBeModifiedHasMovement, "LA UNIDAD")} ");
        ChassisNumber = chassisNumber;
        EngineNumber = engineNumber;
        IsImported = isImported;
    }



   
}

//Método                        Estado anterior permitido           Nuevo estado                        Regla
//ReceiveInMainWarehouse        PurchaseOrder                       InWarehouse                         Solo se puede recibir si fue comprada.
//SendToBranch                  InWarehouse                         InTransit                           Solo si está físicamente en el almacén.
//ReceiveInBranch               InTransit                           Inventory                           Solo si fue enviada.
//MarkAsSold                    Inventory                           Sold                                Solo si está disponible para venta.
//MarkAsStolen                  Cualquiera menos Sold               Stolen                              No se marca robada una vendida.
//MarkAsDamaged                 Cualquiera menos Sold               Damaged                             No se marca dañada una vendida.
//MarkAsDismantled              Damaged o Inventory                 Dismantled                          Solo si está dañada o aún en stock.