using AMartinezTech.Security.Domain.Entities;

namespace AMartinezTech.Security.Domain.Interfaces;

public interface IModuleRepository
{
    Task<Module?> GetByIdAsync(Guid id);
    Task<IEnumerable<Module>> GetAllAsync();
    Task AddAsync(Module module);
    Task UpdateAsync(Module module);

}
