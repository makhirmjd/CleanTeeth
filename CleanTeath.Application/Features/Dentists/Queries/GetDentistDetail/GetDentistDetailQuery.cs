using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistDetail;

public class GetDentistDetailQuery : IRequest<DentistDetailDto>
{
    public required Guid Id { get; set; }
}
