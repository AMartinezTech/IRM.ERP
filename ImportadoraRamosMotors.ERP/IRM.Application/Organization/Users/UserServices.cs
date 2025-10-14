using IRM.Application.Organization.Companies;
using IRM.Core.Exceptions;
using IRM.Core.Organization.Companies;
using IRM.Core.Organization.Users;

namespace IRM.Application.Organization.Users;

public class UserServices(IUserReadRepository readRepository, IUserWriteRepository writeRepository)
{
    private readonly IUserReadRepository _readRepository = readRepository;
    private readonly IUserWriteRepository _writeRepository = writeRepository;

    #region "Read"
    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var result = await _readRepository.GetByIdAsync(id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {id}");
        return UserMapToDto.Single(result);
    }
    public async Task<List<UserDto>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        var result = await _readRepository.FilterAsync(filter, search) ?? throw new ValidationException($"{CommonErrors.NoFilterResults} - Filter");
        return UserMapToDto.List(result);
    }
    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _readRepository.Login(email, password) ?? throw new ValidationException($"{CommonErrors.NotValidCredencials}");

        return true;
    }
    #endregion

    #region "Write"
    public async Task<Guid> CreateAsync(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        if (await _readRepository.ExistsAsync(dto.Email,dto.Phone))
            throw new ValidationException($"{CommonErrors.RegisterAlreadyExists}");


        var entity = UserEntity.Create(
            dto.Email,
            dto.Name,
            dto.Password ?? string.Empty,
            dto.Phone,
            dto.RoleId
            );

        await _writeRepository.CreateAsync(entity);
        return entity.Id;

    }
    public async Task UpdateAsync(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.Update(
            dto.Name,
            dto.Phone,
            dto.RoleId);
        await _writeRepository.UpdateAsync(entity);
    }
    public async Task MarkAsActiveAsync(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsActive();
        await _writeRepository.UpdateAsync(entity);
    }

    public async Task MarkAsInactiveAsync(UserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _readRepository.GetByIdAsync(dto.Id) ?? throw new ValidationException($"{CommonErrors.RegisterNotFound}  - ID {dto.Id}");

        entity.MarkAsInative();
        await _writeRepository.UpdateAsync(entity);
    }
    #endregion
}
