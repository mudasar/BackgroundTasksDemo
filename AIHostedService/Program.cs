using AIHostedService;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<DashboardCacheRefresherHostedService>();
builder.Services.AddDemoServices();

builder.Services.AddControllers();
var app = builder.Build();


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();
