using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
