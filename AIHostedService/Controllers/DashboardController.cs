using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared;
using System.Text.Json;

namespace AIHostedService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public DashboardController(IDistributedCache cache)
        {
            _cache = cache;
        }


        [HttpGet]
        public async Task<DashboardResult> Get()
        {
            var encodedDashboard = await _cache.GetAsync(CacheKeys.Dashboard);
            var dashboard = JsonSerializer.Deserialize<DashboardResult>(encodedDashboard);
            return dashboard;
        }
    }
}
