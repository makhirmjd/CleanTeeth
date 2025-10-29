using CleanTeath.Application.Notifications;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Commands.SendAppointmentReminder;

internal static partial class MapperExtensions
{
    internal static AppointmentReminderDto ToDto(this Appointment appointment)
    {
        return new()
        {
            Id = appointment.Id,
            Date = appointment.TimeInterval.Start,
            Patient = appointment.Patient!.Name,
            PatientEmail = appointment.Patient!.Email.Value,
            Dentist = appointment.Dentist!.Name,
            DentalOffice = appointment.DentalOffice!.Name
        };
    }
}
