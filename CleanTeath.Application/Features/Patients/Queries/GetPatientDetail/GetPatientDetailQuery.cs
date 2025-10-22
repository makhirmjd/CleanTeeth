using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientDetail;

public class GetPatientDetailQuery : IRequest<PatientDetailDto>
{
    public required Guid Id { get; set; }
}
