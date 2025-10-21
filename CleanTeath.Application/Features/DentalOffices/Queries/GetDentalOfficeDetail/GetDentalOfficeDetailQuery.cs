using CleanTeath.Application.Utilities.Mediator;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQuery : IRequest<DentalOfficeDetailDto>
{
    public required Guid Id { get; set; }
}
