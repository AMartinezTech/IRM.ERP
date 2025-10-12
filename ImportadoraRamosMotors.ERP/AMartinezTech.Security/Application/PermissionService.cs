using AMartinezTech.Security.Domain.Enums;
using AMartinezTech.Security.Domain.Interfaces;

namespace AMartinezTech.Security.Application;

public class PermissionService(IRoleModulePermissionRepository permissionRepo)
{
    private readonly IRoleModulePermissionRepository _permissionRepo = permissionRepo;

    public async Task<bool> HasPermissionAsync(Guid roleId, Guid moduleId, ActionType action)
    {
        var permission = await _permissionRepo.GetByRoleAndModuleAsync(roleId, moduleId);
        return permission?.Can(action) ?? false;
    }

    public async Task ValidatePermissionAsync(Guid roleId, Guid moduleId, ActionType action)
    {
        if (!await HasPermissionAsync(roleId, moduleId, action))
            throw new UnauthorizedAccessException("No tiene permiso para ejecutar esta acción.");
    }
}
