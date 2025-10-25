using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentDetail;

public class GetAppointmentDetailQuery : IRequest<AppointmentDetailDto>
{
    public required Guid Id { get; set; }
}
