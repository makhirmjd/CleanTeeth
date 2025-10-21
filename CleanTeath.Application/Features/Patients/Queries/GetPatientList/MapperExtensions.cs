using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientList;

public static partial class MapperExtensions
{
    public static PatientsListDto ToDto(this Patient patient)
    {
        return new PatientsListDto
        {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email.Value
        };
    }
}
