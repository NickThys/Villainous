using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Villainous.Infastructure.EntityFramework;

namespace Villainous.SignalR.Hubs;

public class GameHub:Hub
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public GameHub(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    public async Task JoinGame (string gameCode)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
        using var scope=_serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<VillainousDbContext>();
        var players=await dbContext.Players.Where(x=>x.Game.Code==gameCode).ToListAsync();
    }
}
