using CleanTeath.Application.Notifications;

namespace CleenTeeth.Infrastructure.Notifications;

public class EmailService : INotifications
{
    public Task SendAppointmentConfirmation(AppointmentConfirmationDto appointmentConfirmationDto)
    {
        throw new NotImplementedException();
    }
}
