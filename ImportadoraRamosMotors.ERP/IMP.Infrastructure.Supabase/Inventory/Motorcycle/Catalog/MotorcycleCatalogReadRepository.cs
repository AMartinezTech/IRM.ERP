using IRM.Application.Inventory.Items.Motorcycle.Catalog;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http;
using IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using IRM.Infrastructure.Supabase.Shared.Specification;
using Supabase.Postgrest;
using Supabase.Postgrest.Exceptions; 

namespace IRM.Infrastructure.Supabase.Inventory.Motorcycle.Catalog;

public class MotorcycleCatalogReadRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleCatalogReadRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;

    public async Task<bool> ExistsAsync(Guid brandId, Guid modelId, Guid colorId, int year, int engineDisplacement)
    {
        var client = await _clientFactory.GetClientAsync();

        // Usamos el modelo asociado a la tabla
        var table = client.From<MotorcycleBrandModel>();

        // Filtramos por la propiedad Name (asumiendo que la columna en BD también se llama "name")
        var response = await table
            .Filter("brand_id", Constants.Operator.Equals, brandId.ToString())
            .Filter("model_id", Constants.Operator.Equals, modelId.ToString())
            .Filter("color_id", Constants.Operator.Equals, colorId.ToString())
            .Filter("year", Constants.Operator.Equals, year)
            .Filter("engine_displacement", Constants.Operator.Equals, engineDisplacement)
            .Select("id") // solo seleccionamos un campo para optimizar la consulta
            .Limit(1)     // solo necesitamos verificar si existe al menos uno
            .Get();

        // Retorna true si existe al menos un resultado
        return response.Models.Count != 0;
    }

    public async Task<IReadOnlyList<MotorcycleCatalogEntity>?> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        // Clave de caché dinámica (cambia según los filtros)
        var cacheKey = CacheKeyBuilder.Build("MotorcycleBrands_Filter", filters, search, dateRanges);

        // 🔹 1. Intentamos recuperar desde la caché
        var cached = await _cacheService.GetAsync<IReadOnlyList<MotorcycleCatalogEntity>>(cacheKey);
        if (cached != null)
            return cached;

        // 🔹 2. Obtenemos el cliente Supabase
        var client = await _clientFactory.GetClientAsync();
        var table = client.From<MotorcycleCatalogModel>();

        // 🔹 3. Construimos la especificación genérica
        var spec = new GenericSpecification<MotorcycleCatalogModel>(filters, search, dateRanges);

        // 🔹 4. Aplicamos la especificación al query
        var query = BuildSpecification<MotorcycleCatalogModel>.ApplySpecification(table, spec);

        // 🔹 5. Ejecutamos la consulta
        var result = await query.Get();

        var entities = result.Models.Select(MotorcycleCatalogMap.ToEntity).ToList();

        // 🔹 6. Guardamos el resultado en caché por 60 minutos
        await _cacheService.SetAsync(cacheKey, entities, TimeSpan.FromMinutes(60));

        // 🔹 7. Retornamos los datos
        return entities;
    }

    public async Task<MotorcycleCatalogEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();

            var response = await client
                .From<MotorcycleCatalogModel>()
                .Where(x => x.Id == id)
                .Single();

            if (response == null)
                return null;

            return MotorcycleCatalogMap.ToEntity(response);
        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToGet, "el cátalogo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToGet, "el cátalogo (inesperado)", ex.Message));
        }
    }
}
