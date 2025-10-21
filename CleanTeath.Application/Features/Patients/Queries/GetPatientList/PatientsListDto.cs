namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public class PatientsListDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
