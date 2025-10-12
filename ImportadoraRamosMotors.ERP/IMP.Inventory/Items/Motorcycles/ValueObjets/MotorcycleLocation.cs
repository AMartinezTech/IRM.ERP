namespace IRM.Core.Inventory.Items.Motorcycles.ValueObjets;

public class MotorcycleLocation
{
    public Guid? WarehouseId { get; private set; }
    public Guid? BranchId { get; private set; }
    public Guid? SourceWarehouseId { get; private set; }
    public Guid? TargetBranchId { get; private set; }
    public bool IsInTransit => SourceWarehouseId.HasValue && TargetBranchId.HasValue;

    private MotorcycleLocation() { }

    private MotorcycleLocation(Guid? warehouseId, Guid? branchId, Guid? sourceWarehouseId, Guid? targetBranchId)
    {
        WarehouseId = warehouseId;
        BranchId = branchId;
        SourceWarehouseId = sourceWarehouseId;
        TargetBranchId = targetBranchId;
    }
    /// <summary>
    /// When the motorcycle is new and first enters the main warehouse.
    /// Cuando la motocicleta es nueva y entra por primera vez al almacén principal.
    /// </summary>
    public static MotorcycleLocation Warehouse(Guid warehouseId)
        => new(warehouseId, null,  null, null);

    /// <summary>
    /// When the motorcycle is available at a branch (inventory).
    /// Cuando la motocicleta se encuentra disponible en una sucursal (inventario).
    /// </summary>
    public static MotorcycleLocation Branch(Guid branchId)
        => new(null, branchId,  null, null);

    /// <summary>
    /// When the motorcycle is in transit from a warehouse to a branch.
    /// Cuando la motocicleta se encuentra en tránsito desde un almacén hacia una sucursal.
    /// </summary>
    public static MotorcycleLocation InTransit(Guid sourceWarehouseId, Guid targetWarehouseId)
        => new(null, null,  sourceWarehouseId, targetWarehouseId);

    public override string ToString()
    {
        if (IsInTransit)
            return $"En tránsito desde almacén {SourceWarehouseId} hacia sucursal {TargetBranchId}";

        if (WarehouseId.HasValue)
            return $"En almacén {WarehouseId}";

        if (BranchId.HasValue)
            return $"En sucursal {BranchId}";

        return "Sin ubicación definida";
    }

    public static MotorcycleLocation NewMotocicleUnit() => new();
}
