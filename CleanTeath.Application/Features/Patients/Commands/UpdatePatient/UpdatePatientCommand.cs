using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommand : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
