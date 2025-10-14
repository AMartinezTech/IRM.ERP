using IRM.Core.Exceptions; 
using IRM.Core.Organization.Branches;

namespace IRM.Application.Organization.Branches;

public class BranchServices(IBranchReadRepository readRepository , IBranchWriteRepository writeRepository)
{
    private readonly IBranchReadRepository _readRepository = readRepository;
    private readonly IBranchWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<BranchDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return BranchMapToDto.Single(result);
    }
    public async Task<List<BranchDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return BranchMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(BranchDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.CompanyId, dto.Name))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = BranchEntity.Create(
            dto.Name,
            dto.Address,
            dto.Email,
            dto.Phone,
            dto.CompanyId   
            );

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(BranchDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(
            dto.Name,
            dto.Address,
            dto.Email,
            dto.Phone);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsActiveAsync(BranchDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsActive();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task MarkAsInactiveAsync(BranchDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsInactive();
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion
}
