namespace IRM.Infrastructure.Supabase.Shared.CacheServices;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task RemoveAsync(string key);
    Task<bool> ExistsAsync(string key);
    Task InvalidateAsync(string prefix);
    Task RemoveByPrefixAsync(string prefix);
}
