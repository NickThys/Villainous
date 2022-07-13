using Villainous.Bussines;
using Villainous.Bussines.Helpers;
using Villainous.Infastructure;
using Villainous.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetValue<string>("ConnectionStrings:db");
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<GameCodeHelper>();
builder.Services.ConfigureInfastructure(connString);
builder.Services.AddTransient<GameManager>();
builder.Services.AddSignalR();
builder.Services.AddSingleton<GameHub>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
var app = builder.Build();

app.MapGet("/", () => "This is a SignalR host application!");
app.MapHub<GameHub>("/game");
app.Run();
