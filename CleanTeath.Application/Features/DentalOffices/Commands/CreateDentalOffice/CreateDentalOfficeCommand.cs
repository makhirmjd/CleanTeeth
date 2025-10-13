using CleanTeath.Application.Utilities;

namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
