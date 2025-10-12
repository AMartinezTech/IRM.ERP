namespace IRM.Core.BaseEntities;

public abstract class EntityBase
{

    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; }
    public bool IsActive { get; protected set; } = true;
    public abstract void Validate();
    public abstract void MarkAsActive();
    public abstract void MarkAsInactive();
}
