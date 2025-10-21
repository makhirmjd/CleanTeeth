namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public class PatientsFilterDto
{
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
}
