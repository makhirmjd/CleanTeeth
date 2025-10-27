namespace CleanTeath.Application.Notifications;

public interface INotifications
{
    Task SendAppointmentConfirmation(AppointmentConfirmationDto appointmentConfirmationDto);
}
