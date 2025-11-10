using IRM.Application.Inventory.Items.MotorcycleModel;
using IRM.Core.Exceptions;
using IRM.Core.Inventory.Items.Motorcycles;
using IRM.Infrastructure.Supabase.Http; 
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using Supabase.Postgrest.Exceptions;

namespace IRM.Infrastructure.Supabase.Inventory.MotorcycleModel;

public class MotorcycleModelWriteRepository(ISupabaseClientFactory clientFactory, ICacheService cacheService) : IMotorcycleModelWriteRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;
    private readonly ICacheService _cacheService = cacheService;
    public async Task CreateAsync(MotorcycleModelEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleModelMap.ToModel(entity);
            await client.From<MotorcycleModelModel>().Insert(model);
            await _cacheService.InvalidateAsync("MotorcycleModels_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToCreate, "el modelo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToCreate, "el modelo (inesperado)", ex.Message));
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            await client.From<MotorcycleModelModel>().Where(x => x.Id == id).Delete();
            await _cacheService.InvalidateAsync("MotorcycleModels_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToDelete, "el modelo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToDelete, "el modelo (inesperado)", ex.Message));
        }
    }

    public async Task UpdateAsync(MotorcycleModelEntity entity)
    {
        try
        {
            var client = await _clientFactory.GetClientAsync();
            var model = MotorcycleModelMap.ToModel(entity);
            await client.From<MotorcycleModelModel>().Where(x => x.Id == entity.Id).Update(model);
            await _cacheService.InvalidateAsync("MotorcycleModels_");

        }
        catch (PostgrestException ex)
        {
            throw new BusinessRuleException(message: string.Format(CommonErrors.ErrorToUpdate, "el modelo", ex.Message));
        }
        catch (Exception ex)
        {
            throw new UnexpectedDomainException(message: string.Format(CommonErrors.ErrorToUpdate, "el modelo (inesperado)", ex.Message));
        }
    }
}
