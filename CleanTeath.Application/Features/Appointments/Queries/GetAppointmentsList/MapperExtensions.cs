using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentsList;

internal static partial class MapperExtensions
{
    internal static AppointmentsListDto ToDto(this Appointment appointment)
    {
        return new()
        {
            Id = appointment.Id,
            Patient = appointment.Patient!.Name,
            Dentist = appointment.Dentist!.Name,
            DentalOffice = appointment.DentalOffice!.Name,
            StartDate = appointment.TimeInterval.Start,
            EndDate = appointment.TimeInterval.End,
            Status = appointment.Status.ToString()
        };
    }
}
