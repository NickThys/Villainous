namespace Villainous.Domain;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Game Game { get; set; }
}
