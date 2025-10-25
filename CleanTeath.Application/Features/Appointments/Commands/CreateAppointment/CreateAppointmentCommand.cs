using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommand : IRequest<Guid>
{
    public Guid PatientId { get; set; }
    public Guid DentistId { get; set; }
    public Guid DentalOfficeId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
