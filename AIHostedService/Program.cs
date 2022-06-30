var builder = WebApplication.CreateBuilder(args);

builder.services.AddHostedService<DashboardCacheRefresherHostedService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
