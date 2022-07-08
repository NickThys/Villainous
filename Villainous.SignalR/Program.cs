var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddSignalR();
var app = builder.Build();

app.MapGet("/", () => "This is a SignalR host application!");

app.Run();
