using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Dentists.Commands.DeleteDentist;

public class DeleteDentistCommand : IRequest
{
    public required Guid Id { get; set; }
}
