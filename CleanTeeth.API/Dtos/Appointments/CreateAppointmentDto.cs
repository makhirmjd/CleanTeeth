namespace CleanTeeth.API.Dtos.Appointments;

public class CreateAppointmentDto
{
    public Guid PatientId { get; set; }
    public Guid DentistId { get; set; }
    public Guid DentalOfficeId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
