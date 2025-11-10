
namespace IRM.Infrastructure.Supabase.Shared.Specification;

public class GenericSpecification<T> : ISpecification<T>
{
    public Dictionary<string, object?>? Filters { get; }
    public Dictionary<string, object?>? Search { get; }
    public Dictionary<string, (DateTime? start, DateTime? end)>? DateRanges { get; }
    public Func<T, bool>? Criteria { get; private set; }
    public List<string>? Includes { get; private set; }
    public string? OrderBy { get; private set; }
    public bool IsDescending { get; private set; }
    public int? Skip { get; private set; }
    public int? Take { get; private set; }

    // ✅ Constructor que acepta directamente tus tres diccionarios
    public GenericSpecification(
        Dictionary<string, object?>? filters = null,
        Dictionary<string, object?>? search = null,
        Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        Filters = filters;
        Search = search;
        DateRanges = dateRanges;
        Includes = new List<string>();
    }

    public void SetOrder(string orderBy, bool descending = false)
    {
        OrderBy = orderBy;
        IsDescending = descending;
    }

    public void SetPagination(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public void AddInclude(string include)
    {
        if (Includes == null)
            Includes = new List<string>();

        Includes.Add(include);
    }

    public void SetCriteria(Func<T, bool> criteria)
    {
        Criteria = criteria;
    }

}