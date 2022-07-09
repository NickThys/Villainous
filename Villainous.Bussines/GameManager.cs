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
}
