using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.Dtos.Dentists;

public class UpdateDentistDto
{
    [Required]
    [StringLength(250)]
    public required string Name { get; set; }
    [Required]
    [StringLength(250)]
    public required string Email { get; set; }
}
