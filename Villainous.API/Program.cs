using Villainous.API;
using Villainous.Bussines;
using Villainous.Bussines.Helpers;
using Villainous.Contracts;
using Villainous.Infastructure;

var connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=villainous;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureInfastructure(connString);
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<GameCodeHelper>();
builder.Services.AddTransient<GameManager>();
builder.Services.AddTransient(typeof(IApiHelper<>), typeof(ApiHelper<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/games", (IApiHelper<GameManager> helper, CreateGameRequest request) => helper.Post(l => l.CreateGame(request)));

app.Run();

