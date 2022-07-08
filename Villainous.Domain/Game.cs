namespace Villainous.Domain;

public class Game
{
    public int Id { get; set; }
    public string Code{ get; set; }
    public virtual ICollection<Player> Players { get; set; }
}
