using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentsList;

public class GetAppointmentsListQueryHandler(IAppointmentRepository repository) : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListDto>>
{
    public async Task<List<AppointmentsListDto>> Handle(GetAppointmentsListQuery request)
    {
        IEnumerable<Appointment> appointments =  await repository.GetFiltered(request);
        return [.. appointments.Select(a => a.ToDto())];
    }
}
