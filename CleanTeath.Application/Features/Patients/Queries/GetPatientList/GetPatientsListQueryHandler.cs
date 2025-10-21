using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public class GetPatientsListQueryHandler(IPatientRepository repository) : IRequestHandler<GetPatientsListQuery, List<PatientsListDto>>
{
    public async Task<List<PatientsListDto>> Handle(GetPatientsListQuery request) =>
        [.. (await repository.GetAll()).Select(x => x.ToDto())];
}
