using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Villainous.Infastructure.EntityFramework;

namespace Villainous.Infastructure;

public static class StartupExtention
{
    public static IServiceCollection ConfigureInfastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<VillainousDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
