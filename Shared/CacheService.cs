using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Shared;
public class CacheService : ICacheService
{

    private readonly IDistributedCache _cache;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task RefreshDashboardCacheAsync()
    {
        var rng = new Random();
        var dashbaordResult = new DashboardResult
        {
            AverageSale = rng.Next(1, 2_000),
            LastUpdated = DateTime.UtcNow,
            NumberOfsales = rng.Next(1, 10_000)
        };

        var encodedDashboard = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dashbaordResult));
        await _cache.SetAsync(CacheKeys.Dashboard, encodedDashboard, new DistributedCacheEntryOptions());

        _logger.LogInformation("{cacheKey} cache refreshed", CacheKeys.Dashboard);
    }

    public void RemoveDashboardCache()
    {
        _cache.Remove(CacheKeys.Dashboard);
    }
}
