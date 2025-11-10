using IRM.Application.Inventory.Items.MotorcycleBrand;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http; 
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using Supabase.Postgrest.Exceptions;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;

public class MotorcycleBrandWriteRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleBrandWriteRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;

    public async Task CreateAsync(MotorcycleBrandEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleBrandMap.ToModel(entity);
            await client.From<MotorcycleBrandModel>().Insert(model);
            await _cacheService.InvalidateAsync("MotorcycleBrands_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToCreate, "la marca", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToCreate, "la marca (inesperado)", ex.Message));
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            await client.From<MotorcycleBrandModel>().Where(x => x.Id == id).Delete();
            await _cacheService.InvalidateAsync("MotorcycleBrands_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToDelete, "la marca", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToDelete, "la marca (inesperado)", ex.Message));
        }
    }

    public async Task UpdateAsync(MotorcycleBrandEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleBrandMap.ToModel(entity);
            await client.From<MotorcycleBrandModel>().Where(x => x.Id == entity.Id).Update(model);
            await _cacheService.InvalidateAsync("MotorcycleBrands_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToUpdate, "la marca", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToUpdate, "la marca (inesperado)", ex.Message));
        }
    }
}
