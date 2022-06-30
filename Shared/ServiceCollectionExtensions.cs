using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace Shared;

public static class ServiceCollectionExtensions
{

    public static void AddDemoServices(this IServiceCollection services)
    {
        services.AddSingleton<ICacheService, CacheService>();
        services.AddLogging(loggerConfig =>
        {
            loggerConfig.AddConsole();
            loggerConfig.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = true;
                options.TimestampFormat = "hh:mm:ss ";
            });
            
        });
        services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379");
    }
}
