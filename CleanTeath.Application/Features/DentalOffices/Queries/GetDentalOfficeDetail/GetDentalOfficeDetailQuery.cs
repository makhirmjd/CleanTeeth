using CleanTeath.Application.Utilities;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQuery : IRequest<DentalOfficeDetailDto>
{
    public required Guid Id { get; set; }
}
