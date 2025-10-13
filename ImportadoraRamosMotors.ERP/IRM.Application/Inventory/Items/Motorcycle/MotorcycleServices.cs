using IRM.Core.Enums;
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
    public async Task<List<MotorcycleDto>> FilterAsync(Dictionary<string, object?>? filter = null, Dictionary<string, object?>? search = null)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleDto dto)
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


        if (!Enum.TryParse(dto.Condition, out MotorcycleCondition condition))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CONDICIÓN")} - Condition");



        var entity = MotorcycleEntity.Create(
        dto.Brand,
        dto.Model,
        dto.Color,
        dto.Year,
        condition,
        dto.IsImported,
        dto.EngineDisplacement);

        await _writeRepository.CreateAsync(entity);

        return entity.Id;
    }
    public async Task UpdateAsync(MotorcycleDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        if (!Enum.TryParse(dto.Condition, out MotorcycleCondition condition))
            throw new ValidationException($"{string.Format(CommonErrors.RequiredField, "CONDICIÓN")} - Condition");

        entity.Update(
            dto.Brand,
            dto.Model,
            dto.Color,
            dto.Year,
            condition,
            dto.IsImported,
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
