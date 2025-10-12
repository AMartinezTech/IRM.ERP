namespace IRM.Core.Interfaces;

public interface IGetById<T, Tid> where T : class
{
    Task<T> GetByIdAsync(Tid id);
}
