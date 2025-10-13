using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;

namespace IRM.Application.Inventory.Items.MotorcycleInspection;

public class MotorcycleInspectionServices(IMotorcycleInspectionReadRepository readRepository , IMotorcycleInspectionWriteRepository writeRepository)
{
    private readonly IMotorcycleInspectionReadRepository _readRepository = readRepository;
    private readonly IMotorcycleInspectionWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<MotorcycleInspectionDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleInspectionMapToDto.Single(result);
    }
    public async Task<List<MotorcycleInspectionDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleInspectionMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleInspectionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.MotorcycleUnitId,dto.WarehouseId))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = MotorcycleInspectionEntity.Create(
            dto.PerformedBy,
            dto.Mirrors,
            dto.Battery,
            dto.Tools,
            dto.ConditionNotes,
            dto.MotorcycleUnitId,
            dto.WarehouseId
            );

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(MotorcycleInspectionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.UpdateNotes(dto.ConditionNotes);
        await _writeRepository.UpdateAsync(entity);
    }
     
    #endregion
}
