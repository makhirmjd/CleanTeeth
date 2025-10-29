using CleanTeath.Application.Notifications;
using CleanTeeth.Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Infrastructure;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<INotifications, EmailService>();
        services.AddHttpClient();
        return services;
    }
}
