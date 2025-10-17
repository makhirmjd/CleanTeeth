using CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeath.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeath.Application;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddTransient<IMediator, SimpleMediator>();
        services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
        services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDto>, GetDentalOfficeDetailQueryHandler>();
        services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDto>>, GetDentalOfficesListQueryHandler>();
        return services;
    }
}
