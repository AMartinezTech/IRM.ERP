using IRM.Core.Exceptions;
using IRM.Core.Inventory.Warehouses;

namespace IRM.Application.Inventory.Warehouses;

public class WarehouseServices(IWarehouseReadRepository readRepository, IWarehouseWriteRepository writeRepository)
{
    private readonly IWarehouseReadRepository _readRepository = readRepository;
    private readonly IWarehouseWriteRepository _writeRepository = writeRepository;
    #region "Read"
    public async Task<WarehouseDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return WarehouseMapToDto.Single(result);
    }
    public async Task<List<WarehouseDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return WarehouseMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(WarehouseDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.BranchId,dto.Name))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = WarehouseEntity.Create(dto.BranchId, dto.Name);

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(WarehouseDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(dto.Name);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsActiveAsync(WarehouseDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsActivate();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task MarkAsDeactivateAsync(WarehouseDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsDeactivate();
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion

}
