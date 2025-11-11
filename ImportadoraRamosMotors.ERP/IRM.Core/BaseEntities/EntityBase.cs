namespace IRM.Core.BaseEntities;

public abstract class EntityBase
{

    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public Guid CreatedBy { get; protected set; } 
 
}
