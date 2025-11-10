using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleModel;

public class MotorcycleModelServices(IMotorcycleModelReadRepository readRepository, IMotorcycleModelWriteRepository writeRepository)
{
    public readonly IMotorcycleModelReadRepository _readRepository = readRepository;
    public readonly IMotorcycleModelWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleModelDto> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ValidationException($"{string.Format(CommonErrors.InvalidValue, "ID")}  - ID {id}");

        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleModelMapToDto.Single(result);
    }
    public async Task<List<MotorcycleModelDto>> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        var result = await _readRepository.FilterAsync(filters, search, dateRanges) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleModelMapToDto.List(result);
    }
    #endregion

    #region "Write"

    public async Task<Guid> PersistenceAsync(MotorcycleModelDto dto)
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
    private async Task<Guid> CreateAsync(MotorcycleModelDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var existName = await _readRepository.ExistsAsync(dto.Name, dto.BrandId);
       
        if (existName != null)
        {
            if (existName.Equals(dto.Name, StringComparison.CurrentCultureIgnoreCase))
                throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");
        }


        var entity = MotorcycleModelEntity.Create(dto.Id,dto.BrandId, dto.Name, dto.IsActive);

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    private async Task UpdateAsync(MotorcycleModelDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(dto.Name,dto.IsActive);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        await _writeRepository.DeleteAsync(entity.Id);

    }
    #endregion
}
