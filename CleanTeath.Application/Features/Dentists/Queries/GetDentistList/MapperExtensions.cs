using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistList;

public static partial class MapperExtensions
{
    public static DentistsListDto ToDto(this Dentist dentist)
    {
        return new DentistsListDto
        {
            Id = dentist.Id,
            Name = dentist.Name,
            Email = dentist.Email.Value
        };
    }
}
