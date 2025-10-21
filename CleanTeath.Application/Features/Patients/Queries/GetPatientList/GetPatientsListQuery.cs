using CleanTeath.Application.Utilities.Common;
using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public class GetPatientsListQuery : PatientsFilterDto, IRequest<PaginatedDto<PatientsListDto>>
{
}
