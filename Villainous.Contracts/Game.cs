namespace Villainous.Contracts;

public record CreateGameRequest(string PlayerName);
public record CreateGameResponse(string GameCode);

public record JoinGameRequest(string GameCode,string PlayerName);
public record JoinGameResponse(string GameCode);