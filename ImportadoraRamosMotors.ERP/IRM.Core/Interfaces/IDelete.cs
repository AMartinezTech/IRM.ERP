namespace IRM.Core.Interfaces;

public interface IDelete<T, Tid> where T : class
{
    Task DeleteAsync(Tid entity);
}
