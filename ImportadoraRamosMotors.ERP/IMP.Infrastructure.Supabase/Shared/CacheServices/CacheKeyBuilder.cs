namespace IRM.Infrastructure.Supabase.Shared.CacheServices;

 

public static class CacheKeyBuilder
{
    public static string Build(
        string baseKey,
        Dictionary<string, object?>? filters = null,
        Dictionary<string, object?>? search = null,
        Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        string filtersKey = filters != null
            ? string.Join("_", filters.Select(f => $"{f.Key}:{f.Value}"))
            : string.Empty;

        string searchKey = search != null
            ? string.Join("_", search.Select(s => $"{s.Key}:{s.Value}"))
            : string.Empty;

        string dateKey = dateRanges != null
            ? string.Join("_", dateRanges.Select(d =>
                $"{d.Key}:{d.Value.start:yyyyMMdd}-{d.Value.end:yyyyMMdd}"))
            : string.Empty;

        // Elimina dobles guiones bajos o espacios
        var key = $"{baseKey}_{filtersKey}_{searchKey}_{dateKey}"
            .Replace("__", "_")
            .Trim('_');

        // Si es muy larga, la resumimos con un hash (opcional)
        return key.Length > 128 ? $"{baseKey}_{ComputeHash(key)}" : key;
    }

    private static string ComputeHash(string input)
    {
        using var sha = System.Security.Cryptography.SHA256.Create();
        var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes)[..12]; // abreviado
    }
}
