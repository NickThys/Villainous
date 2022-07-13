using Microsoft.EntityFrameworkCore;
using Villainous.Bussines.Helpers;
using Villainous.Contracts;
using Villainous.Domain;
using Villainous.Infastructure.EntityFramework;

namespace Villainous.Bussines;

public class GameManager
{
    private readonly VillainousDbContext _dbContext;
    private readonly GameCodeHelper _gameCodeHelper;

    public GameManager(VillainousDbContext dbContext,GameCodeHelper gameCodeHelper)
    {
        _dbContext = dbContext;
        _gameCodeHelper = gameCodeHelper;
    }

    public async Task<CreateGameResponse> CreateGame(CreateGameRequest request)
    {
        var gameCode = string.Empty;

        do
        {
            gameCode = _gameCodeHelper.GenerateGameCode();
        }
        while (await _dbContext.Games.AnyAsync(x=>x.Code==gameCode));

        var game = new Game
        {
            Code = gameCode,
        };
        var player = new Player
        {
            Name = request.PlayerName,
            Game = game,
            IsHost = true
        };

        _dbContext.Games.Add(game);
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        return new CreateGameResponse(gameCode);
    }

    public async Task<JoinGameResponse> JoinGame(JoinGameRequest request)
    {
        var game=await _dbContext.Games.SingleOrDefaultAsync(g=>g.Code==request.GameCode);

        if (game == null)
        {
            return null;
        }
        var player = new Player
        {
            Name = request.PlayerName,
            Game = game
        };

        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        return new JoinGameResponse(game.Code);
    }

    public async Task<AbandonGameResponse> AbandonGame(AbandonGameRequest request)
    {
        var player=await _dbContext.Players.Include(o=>o.Game).FirstOrDefaultAsync(p=>p.Name==request.PlayerName&&p.Game.Code==request.GameCode);
        if (player != null)
        {
            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();

            if (_dbContext.Players.Where(p => p.IsHost&& p.Game.Code==request.GameCode).Count() == 0)
            {
                var newHost = await _dbContext.Players.FirstAsync(p => p.Game.Code == request.GameCode);
                newHost.IsHost = true;
                await _dbContext.SaveChangesAsync();
            }
            
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Code == request.GameCode);
            if (game.Players.Count == 0)
            {
                _dbContext.Games.Remove(game);
            }
            await _dbContext.SaveChangesAsync();
        }


        return new AbandonGameResponse();
    }

    public async Task<PlayerReadyResponse> PlayerReady(PlayerReadyRequest request)
    {
        var player = await _dbContext.Players.Include(o => o.Game).FirstOrDefaultAsync(p => p.Name == request.PlayerName && p.Game.Code == request.GameCode);
        if(player == null)
        {
            return null;
        }
        player.IsReady = true;
        await _dbContext.SaveChangesAsync();
        return new PlayerReadyResponse();
    }
}
