using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.Dtos.DentalOffices;

public class CreateDentalOfficeDto
{
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
}
