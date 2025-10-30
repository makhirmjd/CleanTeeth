using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Contracts.Repositories.Models;
using CleanTeath.Application.Notifications;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;

namespace CleanTeath.Application.Features.Appointments.Commands.SendAppointmentReminder;

public class SendAppointmentReminderCommandHandler(IAppointmentRepository repository,
    INotifications notifications) : IRequestHandler<SendAppointmentReminderCommand>
{
    public async Task Handle(SendAppointmentReminderCommand request)
    {
        DateTimeOffset startDate = DateTimeOffset.UtcNow;
        DateTimeOffset endDate = startDate.AddDays(1);
        AppointmentsFilterDto filter = new()
        {
            StartDate = startDate,
            EndDate = endDate,
            AppointmentStatus = AppointmentStatus.Scheduled
        };

        IEnumerable<Appointment> appointments = await repository.GetFiltered(filter);
        foreach (var appointment in appointments)
        {
            await notifications.SendAppointmentReminder(appointment.ToDto());
        }
    }
}
