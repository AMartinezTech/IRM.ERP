using IRM.Core.Exceptions; 
using IRM.Core.Inventory.Items.Motorcycles.TransferOrders;

namespace IRM.Application.Inventory.Items.MotorcycleTransferOrder;

public class MotorcycleTransferOrderServices(IMotorcycleTransferOrderReadRepository readRepository, IMotorcycleTransferOrderWriteRepository writeRepository)
{
    private readonly IMotorcycleTransferOrderReadRepository _readRepository = readRepository;
    private readonly IMotorcycleTransferOrderWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleTransferOrderDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleTransferOrderMapToDto.Single(result);
    }
    public async Task<List<MotorcycleTransferOrderDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleTransferOrderMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleTransferOrderDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (dto.Items == null || dto.Items.Count == 0)
            throw new ArgumentException("La orden de transferencia debe contener al menos un item.");

        // Validar que no haya motocicletas duplicadas
        var duplicatedIds = dto.Items
            .GroupBy(i => i.MotorcycleUnitId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicatedIds.Count != 0)
            throw new InvalidOperationException($"Existen motocicletas duplicadas en la orden: {string.Join(", ", duplicatedIds)}");

        var entity = MotorcycleTransferOrderEntity.Create(
            dto.Code,
            dto.SourceWarehouseId,
            dto.TargetWarehouseId,
            dto.CreatedBy
            );

        foreach (var item in dto.Items)
        {
            entity.AddItem(item.MotorcycleUnitId);
        }

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task MarkAsSent(Guid id, string sentBy)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
       
        entity.MarkAsSent(sentBy);

        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsReceived(Guid id, string receivedBy)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        entity.MarkAsReceived(receivedBy);

        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsCanceled(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        entity.MarkAsCanceled();

        await _writeRepository.UpdateAsync(entity);
    }
   
    #endregion
}
