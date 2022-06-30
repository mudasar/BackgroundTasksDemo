namespace AIHostedService;

public class DashboardCacheRefresherHostedService: IHostedService {

    private readonly ILogger _logger;
    private readonly ICacheService _cacheService;
    public DashboardCacheRefresherHostedService(ILogger<DashboardCacheRefresherHostedService> logger, ICacheService cacheService) {
        _logger = logger;
        _cacheService = cacheService;
    }

    public Task StartAsync(CancellationToken cancellationToken) {
        _logger.LogInformation("DashboardCacheRefresherHostedService is starting.");
        return Task.CompletedTask;
    }
    
}