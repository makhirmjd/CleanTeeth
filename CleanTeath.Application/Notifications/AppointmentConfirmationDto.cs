namespace CleanTeath.Application.Notifications;

public class AppointmentEmailDataDto
{
    public required Guid Id { get; set; }
    public required string Patient { get; set; }
    public required string PatientEmail { get; set; }
    public required string Dentist { get; set; }
    public required string DentalOffice { get; set; }
    public required DateTimeOffset Date { get; set; }
}

public class AppointmentConfirmationDto  : AppointmentEmailDataDto
{
}

public class AppointmentReminderDto : AppointmentEmailDataDto
{

}
