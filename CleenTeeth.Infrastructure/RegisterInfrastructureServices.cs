using CleanTeath.Application.Notifications;
using CleenTeeth.Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace CleenTeeth.Infrastructure;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<INotifications, EmailService>();
        services.AddHttpClient();
        return services;
    }
}
