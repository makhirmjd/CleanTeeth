using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.Dtos.DentalOffices;

public class UpdateDentalOfficeDto
{
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
}
