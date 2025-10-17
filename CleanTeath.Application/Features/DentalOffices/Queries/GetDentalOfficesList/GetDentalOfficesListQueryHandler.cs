using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public class GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository) : 
    IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDto>>
{
    public async Task<List<DentalOfficesListDto>> Handle(GetDentalOfficesListQuery request)
    {
        IEnumerable<DentalOffice> dentalOffices = await repository.GetAll();
        return [.. dentalOffices.Select(d => d.ToDto())];
    }
}
