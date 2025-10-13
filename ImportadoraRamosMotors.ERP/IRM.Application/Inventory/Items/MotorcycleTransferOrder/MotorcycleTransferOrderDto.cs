using IRM.Application.Inventory.Items.MotorcycleInspection;

namespace IRM.Application.Inventory.Items.MotorcycleTransferOrder;

public class MotorcycleTransferOrderDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsActive { get; set; } = true;
    public string Code { get; set; } = string.Empty;
    public Guid SourceWarehouseId { get; set; }
    public Guid TargetWarehouseId { get; set; } 
    public DateTime? SentAt { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public string Status { get; set; } = string.Empty; 
    public string? SentBy { get; set; }
    public string? ReceivedBy { get; set; }
    public List<MotorcycleTransferOrderItemDto> Items { get; set; } = [];
}

public class MotorcycleTransferOrderItemDto()
{
    public Guid Id { get; set; }
    public Guid TransferOrderId { get; set; }
    public Guid MotorcycleUnitId { get; set; }
    public MotorcycleInspectionDto? OutgoingInspection { get; set; }
    public MotorcycleInspectionDto? IncomingInspection { get; set; }
}