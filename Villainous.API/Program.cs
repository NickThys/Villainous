using Microsoft.AspNetCore.Mvc;
using Villainous.API;
using Villainous.Bussines;
using Villainous.Bussines.Helpers;
using Villainous.Contracts;
using Villainous.Infastructure;


var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetValue<string>("ConnectionStrings:db");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureInfastructure(connString);
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<GameCodeHelper>();
builder.Services.AddTransient<GameManager>();
builder.Services.AddTransient(typeof(IApiHelper<>), typeof(ApiHelper<>));
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/games", (IApiHelper<GameManager> helper, CreateGameRequest request) => helper.Post(l => l.CreateGame(request)));
app.MapPost("/games/{GameCode}/join", (IApiHelper<GameManager> helper, [FromRoute] string GameCode, JoinGameRequest request) => helper.Post(l => l.JoinGame(request with { GameCode = GameCode })));
app.MapPost("/games/{GameCode}/abandone/{PlayerName}",(IApiHelper<GameManager> helper,[FromRoute] string GameCode,[FromRoute] string PlayerName)=>helper.Post(l=>l.AbandonGame(new AbandonGameRequest(PlayerName,GameCode))));
app.MapPost("/games/{GameCode}/ready/{PlayerName}", (IApiHelper<GameManager> helper, [FromRoute] string GameCode, [FromRoute] string PlayerName) => helper.Post(l => l.PlayerReady(new PlayerReadyRequest(GameCode,PlayerName))));
app.MapPost("/games/{GameCode}/start",(IApiHelper<GameManager> helper,[FromRoute] string GameCode)=>helper.Post(l=>l.StartGame(new StartGameRequest(GameCode))));
app.Run();

