using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientCommand : IRequest
{
    public required Guid Id { get; set; }
}
