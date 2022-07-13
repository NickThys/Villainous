using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Villainous.Contracts;
using Villainous.Infastructure.EntityFramework;

namespace Villainous.SignalR.Hubs;

public class GameHub:Hub
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public GameHub(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task sendLobbyState(LobbyGameState state)
    {
        if (Clients != null)
        {
            await Clients.Group(state.GameCode).SendAsync("ReceiveLobbyState", state);
        }
    }

    public async Task JoinGame (string gameCode)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
        using var scope=_serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<VillainousDbContext>();
        var players=await dbContext.Players.Where(x=>x.Game.Code==gameCode).ToListAsync();
        await sendLobbyState(new LobbyGameState(players,gameCode));
    }

    public async Task AbandoneGame(string gameCode)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameCode);
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<VillainousDbContext>();
        var players = await dbContext.Players.Where(x => x.Game.Code == gameCode).ToListAsync();
        await sendLobbyState(new LobbyGameState(players, gameCode));
    }

    public async Task PlayerReady(string gameCode)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<VillainousDbContext>();
        var players = await dbContext.Players.Where(x => x.Game.Code == gameCode).ToListAsync();
        await sendLobbyState(new LobbyGameState(players, gameCode));
    }

    public async Task StartGame(string gameCode)
    {
        if (Clients != null)
        {
            await Clients.Group(gameCode).SendAsync("gameStarting", gameCode);
        }
    }
}
