namespace Villainous.Contracts;

public record PlayerReadyRequest(string GameCode,string PlayerName);
public record PlayerReadyResponse();