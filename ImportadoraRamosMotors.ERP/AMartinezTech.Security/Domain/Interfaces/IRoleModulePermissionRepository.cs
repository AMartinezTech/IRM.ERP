using AMartinezTech.Security.Domain.Entities;

namespace AMartinezTech.Security.Domain.Interfaces;

public interface IRoleModulePermissionRepository
{
    Task<RoleModulePermission?> GetByRoleAndModuleAsync(Guid roleId, Guid moduleId);
    Task AddAsync(RoleModulePermission permission);
    Task UpdateAsync(RoleModulePermission permission);
}
