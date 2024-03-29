﻿namespace Villainous.Domain;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsHost { get; set; }

    public bool IsReady { get; set; }
    public virtual Game Game { get; set; }
}
