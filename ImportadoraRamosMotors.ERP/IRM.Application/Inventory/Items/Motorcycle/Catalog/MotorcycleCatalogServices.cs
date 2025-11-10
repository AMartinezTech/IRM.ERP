using IRM.Core.Enums;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle.Catalog;

public class MotorcycleCatalogServices(IMotorcycleCatalogReadRepository readRepository, IMotorcycleCatalogWriteRepository writeRepository)
{
    private readonly IMotorcycleCatalogReadRepository _readRepository = readRepository;
    private readonly IMotorcycleCatalogWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleCatalogDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleCatalogMapToDto.Single(result);
    }
    public async Task<List<MotorcycleCatalogDto>> FilterAsync(Dictionary<string, object?>? filter = null, Dictionary<string, object?>? search = null)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleCatalogMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleCatalogDto dto)
    {

        ArgumentNullException.ThrowIfNull(dto);

        bool exists = await _readRepository.ExistsAsync(
        dto.Brand,
        dto.Model,
        dto.Color,
        dto.Year,
        dto.EngineDisplacement);

        if (exists)
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");

         

        var entity = MotorcycleCatalogEntity.Create(dto.Id,
        dto.Brand,
        dto.Model,
        dto.Color,
        dto.Year,
        dto.Condition, 
        dto.EngineDisplacement);

        await _writeRepository.CreateAsync(entity);

        return entity.Id;
    }
    public async Task UpdateAsync(MotorcycleCatalogDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");
         
        entity.Update( 
            dto.Brand,
            dto.Model,
            dto.Color,
            dto.Year,
            dto.Condition, 
            dto.EngineDisplacement
        );

        await _writeRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        entity.EnsureCanBeDeleted();

        await _writeRepository.DeleteAsync(id);
    }

    #endregion
}
