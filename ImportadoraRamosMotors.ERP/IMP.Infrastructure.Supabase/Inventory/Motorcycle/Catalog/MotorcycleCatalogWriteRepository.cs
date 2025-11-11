using IRM.Application.Inventory.Items.Motorcycle.Catalog;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http;
using IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using Supabase.Postgrest.Exceptions;

namespace IRM.Infrastructure.Supabase.Inventory.Motorcycle.Catalog;

public class MotorcycleCatalogWriteRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleCatalogWriteRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;

    public async Task CreateAsync(MotorcycleCatalogEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleCatalogMap.ToModel(entity);
            await client.From<MotorcycleCatalogModel>().Insert(model);
            await _cacheService.InvalidateAsync("MotorcycleCatalogs_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToCreate, "el cátalogo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToCreate, "el cátalogo (inesperado)", ex.Message));
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            await client.From<MotorcycleCatalogModel>().Where(x => x.Id == id).Delete();
            await _cacheService.InvalidateAsync("MotorcycleCatalogs_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToDelete, "el cátalogo ", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToDelete, "el cátalogo  (inesperado)", ex.Message));
        }
    }

    public async Task UpdateAsync(MotorcycleCatalogEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleCatalogMap.ToModel(entity);
            await client.From<MotorcycleCatalogModel>().Where(x => x.Id == entity.Id).Update(model);
            await _cacheService.InvalidateAsync("MotorcycleCatalogs_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToUpdate, "el cátalogo ", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToUpdate, "el cátalogo  (inesperado)", ex.Message));
        }
    }
}
