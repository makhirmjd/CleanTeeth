using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.Dtos.Patients;

public class UpdatePatientDto
{
    [Required]
    [StringLength(250)]
    public required string Name { get; set; }
    [Required]
    [StringLength(250)]
    public required string Email { get; set; }
}
