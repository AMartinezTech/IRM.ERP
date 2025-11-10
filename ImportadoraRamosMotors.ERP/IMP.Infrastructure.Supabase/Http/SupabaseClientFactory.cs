using Supabase;

namespace IRM.Infrastructure.Supabase.Http;
 
    public class SupabaseClientFactory(string url, string apiKey) : ISupabaseClientFactory
    {
        private readonly string _url = url ?? throw new ArgumentNullException(nameof(url));
        private readonly string _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        private Client? _client;
        private readonly Lock _lock = new();

    public async Task<Client> GetClientAsync()
        {
            if (_client != null)
                return _client;

            lock (_lock)
            {
                if (_client == null)
                {
                    var options = new SupabaseOptions
                    { 
                        AutoConnectRealtime = false,
                        AutoRefreshToken = true, 
                    };

                    _client = new Client(_url, _apiKey, options);
                }
            }

            // Importante: conectar antes de devolverlo
            await _client!.InitializeAsync();
            return _client!;
        }
    }
 
public interface ISupabaseClientFactory
{
    Task<Client> GetClientAsync();
}