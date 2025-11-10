namespace IRM.Infrastructure.Supabase.Shared.Specification;

/// <summary>
/// Define un contrato para aplicar filtros, búsquedas y rangos de fecha
/// a consultas de datos, manteniendo una estructura extensible y genérica.
/// </summary>
/// <typeparam name="T">Tipo de entidad o modelo al que se aplicará la especificación.</typeparam>
public interface ISpecification<T>
{
    // Diccionarios de criterios dinámicos
    Dictionary<string, object?>? Filters { get; }
    Dictionary<string, object?>? Search { get; }
    Dictionary<string, (DateTime? start, DateTime? end)>? DateRanges { get; }

    // Criterio en memoria opcional (para validaciones o filtrado adicional)
    Func<T, bool>? Criteria { get; }

    // Relaciones o joins simulados (si los usas)
    List<string>? Includes { get; }

    // Orden y paginación
    string? OrderBy { get; }
    bool IsDescending { get; }
    int? Skip { get; }
    int? Take { get; }

    // Métodos de configuración
    void SetOrder(string orderBy, bool descending = false);
    void SetPagination(int skip, int take);
    void AddInclude(string include);
    void SetCriteria(Func<T, bool> criteria);
}
