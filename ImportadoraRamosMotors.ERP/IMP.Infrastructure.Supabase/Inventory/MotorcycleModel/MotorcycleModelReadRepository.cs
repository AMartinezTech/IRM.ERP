using IRM.Application.Inventory.Items.MotorcycleModel;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http;
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using IRM.Infrastructure.Supabase.Shared.Specification;
using Supabase.Postgrest;
using Supabase.Postgrest.Exceptions;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleModel;

public class MotorcycleModelReadRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleModelReadRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;
    public async Task<string?> ExistsAsync(string name, Guid brandId)
    {
        var client = await _clientFactory.GetClientAsync();

        // Usamos el modelo asociado a la tabla
        var table = client.From<MotorcycleModelModel>();

        // Filtramos por la propiedad Name (asumiendo que la columna en BD también se llama "name")
        var result = await table
            .Filter("name", Constants.Operator.Equals, name)
            .Filter("brand_id", Constants.Operator.Equals, brandId.ToString())
            .Select("name") // solo seleccionamos un campo para optimizar la consulta
            .Limit(1)     // solo necesitamos verificar si existe al menos uno
            .Get();

        // Si hay al menos un registro, entonces existe
        return result.Models.FirstOrDefault()?.Name;
    }

    public async Task<IReadOnlyList<MotorcycleModelEntity>?> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        try
        {
            // Clave de caché dinámica (cambia según los filtros)
            var cacheKey = CacheKeyBuilder.Build("MotorcycleModels_Filter", filters, search, dateRanges);

            // 🔹 1. Intentamos recuperar desde la caché
            var cached = await _cacheService.GetAsync<IReadOnlyList<MotorcycleModelEntity>>(cacheKey);
            if (cached != null)
                return cached;

            // 🔹 2. Obtenemos el cliente Supabase
            var client = await _clientFactory.GetClientAsync();
            var table = client.From<MotorcycleModelModel>();

            // 🔹 3. Construimos la especificación genérica
            var spec = new GenericSpecification<MotorcycleModelModel>(filters, search, dateRanges);

            // 🔹 4. Aplicamos la especificación al query
            var query = BuildSpecification<MotorcycleModelModel>.ApplySpecification(table, spec);

            // 🔹 5. Ejecutamos la consulta
            var result = await query.Get();

            var entities = result.Models.Select(MotorcycleModelMap.ToEntity).ToList();

            // 🔹 6. Guardamos el resultado en caché por 60 minutos
            await _cacheService.SetAsync(cacheKey, entities, TimeSpan.FromMinutes(60));

            // 🔹 7. Retornamos los datos
            return entities;
        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToGet, "el modelo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToGet, "el modelo (inesperado)", ex.Message));
        }
    }

    public async Task<MotorcycleModelEntity?> GetByIdAsync(Guid id)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();

            var response = await client
                .From<MotorcycleModelModel>()
                .Where(x => x.Id == id)
                .Single();

            if (response == null)
                return null;

            return MotorcycleModelMap.ToEntity(response);
        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToGet, "el modelo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToGet, "el modelo (inesperado)", ex.Message));
        }
    }
}
