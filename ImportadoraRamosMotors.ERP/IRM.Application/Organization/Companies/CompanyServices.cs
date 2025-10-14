 
using IRM.Core.Exceptions;
using IRM.Core.Organization.Companies; 

namespace IRM.Application.Organization.Companies;

public class CompanyServices(ICompanyReadRepository readRepository , ICompanyWriteRepository writeRepository)
{
    private readonly ICompanyReadRepository _readRepository = readRepository;
    private readonly ICompanyWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<CompanyDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return CompanyMapToDto.Single(result);
    }
    public async Task<List<CompanyDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return CompanyMapToDto.List(result);
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(CompanyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.Rnc))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = CompanyEntity.Create(
            dto.Name,
            dto.Rnc,
            dto.Address,
            dto.Email,
            dto.Phone 
            );

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(CompanyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(
            dto.Name,
            dto.Rnc,
            dto.Address,
            dto.Email,
            dto.Phone);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsActiveAsync(CompanyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsActive();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task MarkAsInactiveAsync(CompanyDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsInactive();
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion
}
