using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Queries.GetDentistDetail;

public static partial class MapperExtensions
{
    public static DentistDetailDto ToDto(this Dentist dentist) =>
        new()
        {
            Id = dentist.Id,
            Name = dentist.Name,
            Email = dentist.Email.Value
        };
}
