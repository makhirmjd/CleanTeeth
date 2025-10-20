using CleanTeath.Application.Features.Patients.Commands.CreatePatient;
using CleanTeath.Application.Utilities;
using CleanTeeth.API.Dtos.Patients;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreatePatientDto createPatientDto)
    {
        var command = new CreatePatientCommand
        {
            Name = createPatientDto.Name,
            Email = createPatientDto.Email
        };
        Guid id = await mediator.Send(command);
        return Ok(id);
    }
}
