
using Villainous.Domain;

namespace Villainous.Contracts;

public record LobbyGameState(List<Player> Players,string GameCode);
