namespace IRM.Core.Interfaces;

public interface IGetAll<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(); 
}
