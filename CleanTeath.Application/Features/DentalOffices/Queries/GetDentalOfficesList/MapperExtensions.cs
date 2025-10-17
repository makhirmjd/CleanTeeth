using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public static class MapperExtensions
{
    public static DentalOfficesListDto ToDto(this DentalOffice dentalOffice)
    {
        return new DentalOfficesListDto
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
    }
}
