namespace CleanTeath.Application.Features.Patients.Queries.GetPatientDetail;

public class PatientDetailDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
