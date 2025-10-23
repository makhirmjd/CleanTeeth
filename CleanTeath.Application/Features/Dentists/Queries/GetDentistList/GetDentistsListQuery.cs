using CleanTeath.Application.Utilities.Common;
using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistList;

public class GetDentistsListQuery : DentistsFilterDto, IRequest<PaginatedDto<DentistsListDto>>
{
}
