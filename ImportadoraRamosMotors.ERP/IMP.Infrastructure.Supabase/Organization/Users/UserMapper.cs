using IRM.Core.Organization.Users;

namespace IRM.Infrastructure.Supabase.Organization.Users;

public static class UserMapper
{
    public static UserEntity ToEntity(UserModel model)
    {
        var entity = UserEntity.Create(model.Email, model.Name, null, model.Phone, model.RoleId,model.BranchId,model.HasGlobalAccess);
        return entity;
    }

    public static UserModel ToModel(UserEntity entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            Email = entity.Email,
            Name = entity.Name,
            Password = entity.Password,
            Phone = entity.Phone,
            RoleId = entity.RoleId,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt,
            BranchId = entity.BranchId ?? Guid.Empty,
            HasGlobalAccess = entity.HasGlobalAccess,
        };
    }
}
