using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities.Common;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistList;

public class GetDentistsListQueryHandler(IDentistRepository repository) : IRequestHandler<GetDentistsListQuery, PaginatedDto<DentistsListDto>>
{
    public async Task<PaginatedDto<DentistsListDto>> Handle(GetDentistsListQuery request)
    {
        IEnumerable<Dentist> dentists = await repository.GetFiltered(request);
        int totalAmountOfRecords = await repository.GetTotalAmountOfRecords();
        List<DentistsListDto> dentistsDtos = [.. dentists.Select(x => x.ToDto())];
        PaginatedDto<DentistsListDto> paginatedDto = new()
        {
            Items = dentistsDtos,
            TotalAmountOfRecords = totalAmountOfRecords,
            CurrentPage = request.Page,
            PageSize = request.RecordsPerPage,
            PageCount = (int)Math.Ceiling((double)totalAmountOfRecords / request.RecordsPerPage),
        };
        return paginatedDto;
    }
}
