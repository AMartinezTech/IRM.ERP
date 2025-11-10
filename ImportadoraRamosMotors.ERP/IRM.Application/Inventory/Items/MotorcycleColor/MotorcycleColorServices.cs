using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleColor;

public class MotorcycleColorServices(IMotorcycleColorReadRepository readRepository, IMotorcycleColorWriteRepository writeRepository)
{
    private readonly IMotorcycleColorReadRepository _readRepository = readRepository;
    private readonly IMotorcycleColorWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleColorDto> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.InvalidValue, "ID")}  - ID {id}");

        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleColorMapToDto.Single(result);
    }
    public async Task<List<MotorcycleColorDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = await _readRepository.FilterAsync(filters, search, dateRanges) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleColorMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> PersistenceAsync(MotorcycleColorDto dto)
    {
        if (dto.Id == Guid.Empty)
        {
            return await CreateAsync(dto);
        }
        else
        {
            await UpdateAsync(dto);
            return dto.Id;
        }
    }
    private async Task<Guid> CreateAsync(MotorcycleColorDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var existName = await _readRepository.ExistsAsync(dto.Name);

        if (existName != null)
        { 
            if (existName.Equals(dto.Name, StringComparison.CurrentCultureIgnoreCase))
                throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");
        }

        var entity = MotorcycleColorEntity.Create(dto.Id, dto.Name, dto.IsActive);

        await _writeRepository.CreateAsync(entity);
        
        return entity.Id;

    }
    private async Task UpdateAsync(MotorcycleColorDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(dto.Name, dto.IsActive);

        await _writeRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        await _writeRepository.DeleteAsync(entity.Id);

    }
    #endregion
}
