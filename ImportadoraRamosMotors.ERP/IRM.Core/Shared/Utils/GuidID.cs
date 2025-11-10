namespace IRM.Core.Shared.Utils;

public class GuidID
{
    public static Guid Generate(Guid id)
    {
      return id == Guid.Empty ? Guid.NewGuid() : id;
    }
}
