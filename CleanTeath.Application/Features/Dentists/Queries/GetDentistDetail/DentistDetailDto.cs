namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistDetail;

public class DentistDetailDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
