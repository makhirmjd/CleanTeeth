using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentDetail;

internal static partial class MapperExtensions
{
    internal static AppointmentDetailDto ToDto(this Appointment appointment)
    {
        return new AppointmentDetailDto
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
