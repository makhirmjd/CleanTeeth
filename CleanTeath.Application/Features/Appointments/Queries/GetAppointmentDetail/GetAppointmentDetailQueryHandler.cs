using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentDetail;

public class GetAppointmentDetailQueryHandler(IAppointmentRepository repository) : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDto>
{
    public async Task<AppointmentDetailDto> Handle(GetAppointmentDetailQuery request)
    {
        Appointment appointment = await repository.GetById(request.Id) ?? throw new NotFoundException();
        return appointment.ToDto();
    }
}
