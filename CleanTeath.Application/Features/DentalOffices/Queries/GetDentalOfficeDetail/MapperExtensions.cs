using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public static class MapperExtensions
{
    public static DentalOfficeDetailDto ToDto(this DentalOffice dentalOffice) =>
        new()
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
}
