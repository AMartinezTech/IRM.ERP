using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace IRM.Infrastructure.Supabase.Shared.CacheServices;

public class CacheService : ICacheService
{
    private readonly MemoryCache _cache;
    private readonly ConcurrentDictionary<string, bool> _keys; // 🔹 Mantiene las claves registradas


    public CacheService()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
        _keys = new ConcurrentDictionary<string, bool>();
    }

    public Task<T?> GetAsync<T>(string key)
    {
        _cache.TryGetValue(key, out T? value);
        return Task.FromResult(value);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(30)
        };

        _cache.Set(key, value, options);
        _keys.TryAdd(key, true); // 🔹 Guardamos la clave para futuras invalidaciones
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        _keys.TryRemove(key, out _); // 🔹 Eliminamos también del registro
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(string key)
    {
        var exists = _cache.TryGetValue(key, out _);
        return Task.FromResult(exists);
    }
    /// <summary>
    /// ✅ Invalida una o varias claves relacionadas a un módulo o conjunto de datos.
    /// Ejemplo: await InvalidateAsync("InventoryTransfers");
    /// </summary>
    public Task InvalidateAsync(string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix))
            return Task.CompletedTask;

        var keysToRemove = _keys.Keys
            .Where(k => k.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var key in keysToRemove)
        {
            _cache.Remove(key);
            _keys.TryRemove(key, out _);
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// ✅ Elimina todas las entradas que empiecen con un prefijo específico.
    /// Ejemplo: await RemoveByPrefixAsync("MotorcycleColors_");
    /// </summary>
    public Task RemoveByPrefixAsync(string prefix)
    {
        return InvalidateAsync(prefix);
    } 
}
