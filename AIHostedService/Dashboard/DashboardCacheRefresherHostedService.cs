using Shared;

namespace AIHostedService;

public class DashboardCacheRefresherHostedService : IHostedService
{

    private readonly ILogger _logger;
    private readonly ICacheService _cacheService;
    public DashboardCacheRefresherHostedService(ILogger<DashboardCacheRefresherHostedService> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("DashboardCacheRefresherHostedService is starting.");
        RefreshCacheAsync(cancellationToken);
        return Task.CompletedTask;
    }

    private async void RefreshCacheAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await _cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Job {jobName} threw an error", nameof(DashboardCacheRefresherHostedService));
            }
            await Task.Delay(5000, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping {jobName}", nameof(DashboardCacheRefresherHostedService));
        _cacheService.RemoveDashboardCache();

        return Task.CompletedTask;
    }
}