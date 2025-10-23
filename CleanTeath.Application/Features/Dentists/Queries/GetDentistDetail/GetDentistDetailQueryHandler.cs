using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistDetail;

public class GetDentistDetailQueryHandler(IDentistRepository repository) : IRequestHandler<GetDentistDetailQuery, DentistDetailDto>
{
    public async Task<DentistDetailDto> Handle(GetDentistDetailQuery request)
    {
        Dentist dentist = await repository.GetById(request.Id) ?? throw new NotFoundException();
        return dentist.ToDto();
    }
}
