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
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return MotorcycleColorMapToDto.Single(result);
    }
    public async Task<List<MotorcycleColorDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return MotorcycleColorMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(MotorcycleColorDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.Name))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = MotorcycleColorEntity.Create(dto.Name);

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(MotorcycleColorDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(dto.Name);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");

        await _writeRepository.DeleteAsync(entity.Id);

    }
    #endregion
}
