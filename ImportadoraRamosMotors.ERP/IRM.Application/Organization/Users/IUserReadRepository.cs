using IRM.Core.Interfaces;
using IRM.Core.Organization.Users;

namespace IRM.Application.Organization.Users;

public interface IUserReadRepository : IFilter<UserEntity>, IGetById<UserEntity, Guid>
{
    Task<bool> ExistsAsync(string email, string phone);
    Task<UserEntity?> Login(string email, string password);
}