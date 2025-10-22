using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Patients.Queries.GetPatientDetail;

public static partial class MapperExtensions
{
    public static PatientDetailDto ToDto(this Patient patient) =>
        new()
        {
            Id = patient.Id,
            Name = patient.Name,
            Email = patient.Email.Value
        };
}
