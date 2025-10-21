using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities.Common;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public class GetPatientsListQueryHandler(IPatientRepository repository) : IRequestHandler<GetPatientsListQuery, PaginatedDto<PatientsListDto>>
{
    public async Task<PaginatedDto<PatientsListDto>> Handle(GetPatientsListQuery request)
    {
        IEnumerable<Patient> patients = await repository.GetFiltered(request);
        int totalAmountOfRecords = await repository.GetTotalAmountOfRecords();
        List<PatientsListDto> patientsDtos = [..patients.Select(x => x.ToDto())];
        PaginatedDto<PatientsListDto> paginatedDto = new()
        {
            Items = patientsDtos,
            TotalAmountOfRecords = totalAmountOfRecords,
            CurrentPage = request.Page,
            PageSize = request.RecordsPerPage,
            PageCount = (int)Math.Ceiling((double)totalAmountOfRecords / request.RecordsPerPage),
        };
        return paginatedDto;
    }
}
