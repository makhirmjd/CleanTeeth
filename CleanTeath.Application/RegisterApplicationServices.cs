using CleanTeath.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeath.Application;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.Scan(scan => scan
            .FromAssembliesOf(typeof(RegisterApplicationServices))
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}
