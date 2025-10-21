using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}
