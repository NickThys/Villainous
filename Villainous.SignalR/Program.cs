using Villainous.Bussines;
using Villainous.Bussines.Helpers;
using Villainous.Infastructure.EntityFramework;
using Villainous.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<GameCodeHelper>();
builder.Services.AddDbContext<VillainousDbContext>();
builder.Services.AddTransient<GameManager>();
builder.Services.AddSignalR();
builder.Services.AddSingleton<GameHub>();
var app = builder.Build();

app.MapGet("/", () => "This is a SignalR host application!");
app.MapHub<GameHub>("/game");
app.Run();
