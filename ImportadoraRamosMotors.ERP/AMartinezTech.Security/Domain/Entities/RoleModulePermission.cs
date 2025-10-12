using AMartinezTech.Security.Domain.Enums;

namespace AMartinezTech.Security.Domain.Entities;

public class RoleModulePermission(Guid roleId, Guid moduleId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RoleId { get; private set; } = roleId;
    public Guid ModuleId { get; private set; } = moduleId;

    private readonly List<ActionType> _allowedActions = [];
    public IReadOnlyCollection<ActionType> AllowedActions => _allowedActions.AsReadOnly();

    public void Grant(ActionType action)
    {
        if (!_allowedActions.Contains(action))
            _allowedActions.Add(action);
    }

    public void Revoke(ActionType action)
    {
        if (_allowedActions.Contains(action))
            _allowedActions.Remove(action);
    }

    public bool Can(ActionType action) => _allowedActions.Contains(action);
}
