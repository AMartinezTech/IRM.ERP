using IRM.Application.Organization.Users;
using IRM.Core.Organization.Users;
using IRM.Infrastructure.Supabase.Http;

namespace IRM.Infrastructure.Supabase.Organization.Users;

public class UserReadRepository(ISupabaseClientFactory clientFactory) : IUserReadRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;

    public async Task<bool> ExistsAsync(string email, string phone)
    {
        var client = await _clientFactory.GetClientAsync();

        var result = await client
        .From<UserModel>()
        .Where(u => u.Email == email)
        .Where(u => u.Phone == phone)
        .Single();

        //return result ?? true : false;
        return true;
    }

    public Task<IReadOnlyList<UserEntity>?> FilterAsync(Dictionary<string, object?>? filter, Dictionary<string, object?>? search)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<UserEntity>?> FilterAsync(Dictionary<string, object?>? filters = null, Dictionary<string, object?>? search = null, Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        var client = await _clientFactory.GetClientAsync();

        var result = await client.From<UserModel>()
            .Where(u => u.Id == id)
            .Single();

        return result == null ? null : UserMapper.ToEntity(result);
    }

    public Task<UserEntity?> Login(string email, string password)
    {
        throw new NotImplementedException();
    }
}
