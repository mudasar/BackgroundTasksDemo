namespace Shared
{
    public interface ICacheService
    {
        Task RefreshDashboardCacheAsync();
        void RemoveDashboardCache();
    }
}