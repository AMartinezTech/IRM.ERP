using IRM.Application.Inventory.Items.MotorcycleColor;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http;
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using Supabase.Postgrest.Exceptions;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleColor;

public class MotorcycleColorWriteRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleColorWriteRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;

    public async Task CreateAsync(MotorcycleColorEntity entity)
    { 
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleColorMap.ToModel(entity);
            await client.From<MotorcycleColorModel>().Insert(model);
            await _cacheService.InvalidateAsync("MotorcycleColors_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToCreate, "el color", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToCreate, "el color (inesperado)", ex.Message));
        }
    }

    public async Task DeleteAsync(Guid id)
    { 
        try
        {
            var client = await _clientFactory.GetClientAsync();
            await client.From<MotorcycleColorModel>().Where(x => x.Id == id).Delete();
            await _cacheService.InvalidateAsync("MotorcycleColors_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToDelete, "el color", ex.Message)); 
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToDelete, "el color (inesperado)", ex.Message));
        }
    }

    public async Task UpdateAsync(MotorcycleColorEntity entity)
    {
       
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleColorMap.ToModel(entity);
            await client.From<MotorcycleColorModel>().Where(x => x.Id == entity.Id).Update(model);
            await _cacheService.InvalidateAsync("MotorcycleColors_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToUpdate, "el color", ex.Message)); 
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToUpdate, "el color (inesperado)", ex.Message));
        }
    }
}
