using System.Net.Http.Json;
using Villainous.Contracts;

namespace Villainous.Client;

public class GameClient
{
    //todo Add url
    private static string _apiHost = "https://localhost:7175";

    public async Task<string> CreateGame(string playerName)
    {
        var request = new CreateGameRequest(playerName);

        var client=new HttpClient();
        var response = await client.PostAsJsonAsync($"{_apiHost}/games", request);
        var createGameResponse=await response.Content.ReadFromJsonAsync<CreateGameResponse>();

        return createGameResponse.GameCode;
    }

    public async Task<string> JoinGame(string gameCode,string playerName)
    {
        var request =new JoinGameRequest(gameCode, playerName);

        var client = new HttpClient();
        var response = await client.PostAsJsonAsync($"{_apiHost}/games/{gameCode}/join", request);
        var joinGameResponse=await response.Content.ReadFromJsonAsync<JoinGameRequest>();

        return joinGameResponse.GameCode;
    }
}
