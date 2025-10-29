using CleanTeath.Application.Contracts.Repositories.Models;
using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentsList;

public class GetAppointmentsListQuery : AppointmentsFilterDto, IRequest<List<AppointmentsListDto>>
{
}
