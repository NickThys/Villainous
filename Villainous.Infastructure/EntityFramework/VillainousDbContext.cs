using Microsoft.EntityFrameworkCore;
using Villainous.Domain;

namespace Villainous.Infastructure.EntityFramework;

public class VillainousDbContext:DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
    public VillainousDbContext(DbContextOptions options) : base(options)
    {

    }

}
