namespace IRM.Application.Purchasing.Orders;

public class PurcharseOrderDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public string Code { get; set; } = string.Empty;
    public DateTime? ReceivedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ReceivedBy { get; set; } 

    public List<PurcharseOrderItemDto> Items = []; 
    public decimal Total => Items?.Sum(x => x.Total) ?? 0m;

}
public class PurcharseOrderItemDto
{
    public Guid Id { get; set; }
    public Guid PurchaseOrderId { get; set; }
    public Guid MotorcycleUnitId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => Quantity * UnitPrice ;
}