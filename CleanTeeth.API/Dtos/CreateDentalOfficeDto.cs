using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.Dtos;

public class CreateDentalOfficeDto
{
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
}
