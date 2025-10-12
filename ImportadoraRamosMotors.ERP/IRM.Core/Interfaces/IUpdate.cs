namespace IRM.Core.Interfaces;

public interface IUpdate<T> where T : class
{
    Task UpdateAsync(T entity);
}
