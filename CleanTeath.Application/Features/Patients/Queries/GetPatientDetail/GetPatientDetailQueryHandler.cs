using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientDetail;

public class GetPatientDetailQueryHandler(IPatientRepository repository) : IRequestHandler<GetPatientDetailQuery, PatientDetailDto>
{
    public async Task<PatientDetailDto> Handle(GetPatientDetailQuery request)
    {
        Patient patient = await repository.GetById(request.Id) ?? throw new NotFoundException();
        return patient.ToDto();
    }
}
