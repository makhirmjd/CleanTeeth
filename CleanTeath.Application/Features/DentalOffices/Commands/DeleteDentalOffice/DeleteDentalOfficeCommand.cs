using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.DentalOffices.Commands.DeleteDentalOffice;

public class DeleteDentalOfficeCommand : IRequest
{
    public required Guid Id { get; set; }
}
