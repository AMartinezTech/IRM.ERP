using IRM.Core.Organization.Users;

namespace IRM.Application.Organization.Users;

internal class UserMapToDto
{
    internal static UserDto Single(UserEntity entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Email = entity.Email,
            Name = entity.Name,
            Password = null,
            Phone = entity.Phone,
            RoleId = entity.RoleId,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt,
            HasGlobalAccess = entity.HasGlobalAccess,
            BranchId = entity.BranchId,

        };
    }

    internal static List<UserDto> List(IEnumerable<UserEntity> entities)
    {
        return [.. entities.Select(Single)];
    }
}
