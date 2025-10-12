namespace IRM.Core.Interfaces;

public interface IFilter<T> where T : class
{
    Task<IReadOnlyList<T>> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string,object?> search);
}
