using IRM.Application.Organization.Users;
using IRM.Core.Organization.Users;
using IRM.Infrastructure.Supabase.Http;

namespace IRM.Infrastructure.Supabase.Organization.Users;

public class UserWriteRepository(ISupabaseClientFactory clientFactory) : IUserWriteRepository
{
    private readonly ISupabaseClientFactory _clientFactory = clientFactory;

    public async Task CreateAsync(UserEntity entity)
    {
        var client = await _clientFactory.GetClientAsync();
        var model = UserMapper.ToModel(entity);
        await client.From<UserModel>().Insert(model);
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        var client = await _clientFactory.GetClientAsync();
        var model = UserMapper.ToModel(entity);
        await client.From<UserModel>().Update(model);
    }
}
