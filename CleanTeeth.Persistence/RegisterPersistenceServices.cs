using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Persistence;

public static class RegisterPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<CleanTeethDbContext>(options =>
            options.UseSqlServer("name=CleanTeethConnectionString"));
        return services;
    }
}
