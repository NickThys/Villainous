namespace Villainous.Contracts;

public record CreateGameRequest(string PlayerName);
public record CreateGameResponse(string GameCode);

public record JoinGameRequest(string GameCode,string PlayerName);
public record JoinGameResponse(string GameCode);

public record AbandonGameRequest(string PlayerName,string GameCode);
public record AbandonGameResponse();

public record StartGameRequest(string GameCode);
public record StartGameResponse();