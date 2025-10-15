using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository repository) : 
    IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDto>
{
    public async Task<DentalOfficeDetailDto> Handle(GetDentalOfficeDetailQuery request)
    {
        DentalOffice? dentalOffice = await repository.GetById(request.Id);
        if (dentalOffice is null)
        {
            throw new NotFoundException();
        }
        var dto = new DentalOfficeDetailDto 
        { 
            Id = dentalOffice.Id,
            Name = dentalOffice.Name 
        };
        return dto;
    }
}
