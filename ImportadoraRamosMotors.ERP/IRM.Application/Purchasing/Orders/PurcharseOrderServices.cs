
using IRM.Core.Exceptions;
using IRM.Core.Purchasing.PurcharseOrders;

namespace IRM.Application.Purchasing.Orders;

public class PurcharseOrderServices(IPurcharseOrderReadRepository readRepository, IPurcharseOrderWriteRepository writeRepository)
{
    private readonly IPurcharseOrderReadRepository _readRepository = readRepository;
    private readonly IPurcharseOrderWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<PurcharseOrderDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return PurcharseOrderMapToDto.Single(result);
    }
    public async Task<List<PurcharseOrderDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return PurcharseOrderMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(PurcharseOrderDto dto)
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

        var entity = PurcharseOrderEntity.Create(
            dto.Code, 
            dto.CreatedBy);

        foreach (var item in dto.Items)
        {
            entity.AddItem(item.Id,item.Quantity,item.UnitPrice);
        }

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }

    public async Task MarkAsReceived(Guid id, string receivedBy)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        entity.MarkAsReceived(receivedBy);

        await _writeRepository.UpdateAsync(entity);
    }

    #endregion
}
