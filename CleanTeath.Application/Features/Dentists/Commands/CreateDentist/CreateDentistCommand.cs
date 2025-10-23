using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Dentists.Commands.CreateDentist;

public class CreateDentistCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}
