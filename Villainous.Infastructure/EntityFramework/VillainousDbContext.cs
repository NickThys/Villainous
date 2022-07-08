using Microsoft.EntityFrameworkCore;

namespace Villainous.Infastructure.EntityFramework;

public class VillainousDbContext:DbContext
{
    public VillainousDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=villainous;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connString);
    }
}
