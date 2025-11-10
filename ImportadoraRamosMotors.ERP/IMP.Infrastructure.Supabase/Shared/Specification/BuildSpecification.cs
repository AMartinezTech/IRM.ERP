using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using Supabase.Postgrest.Models;

namespace IRM.Infrastructure.Supabase.Shared.Specification;


public static class BuildSpecification<TModel> where TModel : BaseModel, new()
{
   
    public static IPostgrestTable<TModel> ApplySpecification(IPostgrestTable<TModel> query, ISpecification<TModel> spec)
    {
        if (spec == null)
            return query;

        // Aplicar filtros exactos
        if (spec.Filters != null)
        {
            foreach (var filter in spec.Filters)
                query = query.Filter(filter.Key, Constants.Operator.Equals, filter.Value);
        }

        // Búsquedas parciales
        if (spec.Search != null)
        {
            foreach (var search in spec.Search)
                query = query.Filter(search.Key, Constants.Operator.ILike, $"%{search.Value}%");
        }

        // Rangos de fechas
        if (spec.DateRanges != null)
        {
            foreach (var range in spec.DateRanges)
            {
                if (range.Value.start.HasValue)
                    query = query.Filter(range.Key, Constants.Operator.GreaterThanOrEqual, range.Value.start.Value);
                if (range.Value.end.HasValue)
                    query = query.Filter(range.Key, Constants.Operator.LessThanOrEqual, range.Value.end.Value);
            }
        }

        // Ordenamiento
        if (!string.IsNullOrEmpty(spec.OrderBy))
        {
            var direction = spec.IsDescending
                ? Constants.Ordering.Descending
                : Constants.Ordering.Ascending;

            query = query.Order(spec.OrderBy, direction);
        }

        // Paginación
        if (spec.Skip.HasValue && spec.Take.HasValue)
            query = query.Range(spec.Skip.Value, spec.Skip.Value + spec.Take.Value - 1);

        return query;
    }
}
