using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.Motorcycle;

public class MotorcycleServices(IMotorcycleReadRepository readRepository, IMotorcycleWriteRepository writeRepository)
{
    private readonly IMotorcycleReadRepository _readRepository = readRepository;
    private readonly IMotorcycleWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleMapToDto.Single(result);
    }
    public async Task<List<MotorcycleDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsByChassisAsync(dto.ChassisNumber, dto.EngineNumber))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = MotorcycleEntity.Create(
            dto.MotorcycleCatalogId,
            dto.ChassisNumber,
            dto.EngineNumber,
            dto.IsImported
            );

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(MotorcycleDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

         var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");
         
        entity.Update(dto.ChassisNumber,dto.EngineNumber, dto.IsImported);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        entity.EnsureCanBeDeleted();
        await _writeRepository.DeleteAsync(entity.Id);

    }
     
    #endregion
}
