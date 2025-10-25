namespace CleanTeath.Application.Features.Appointments.Queries.GetAppointmentDetail;

public class AppointmentDetailDto
{
    public required Guid Id { get; set; }
    public required string Patient { get; set; }
    public required string Dentist { get; set; }
    public required string DentalOffice { get; set; }
    public required DateTimeOffset StartDate { get; set; }
    public required DateTimeOffset EndDate { get; set; }
    public required string Status { get; set; }
}
