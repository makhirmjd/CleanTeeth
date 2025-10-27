using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentCommand : IRequest
{
    public required Guid Id { get; set; }
}
