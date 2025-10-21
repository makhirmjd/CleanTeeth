using CleanTeath.Application.Features.Patients.Commands.CreatePatient;
using CleanTeath.Application.Features.Patients.Queries.GetPatientList;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.API.Dtos.Patients;
using CleanTeeth.API.Utilities;
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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPatientsListQuery query)
    {
        var result = await mediator.Send(query);
        HttpContext.InsertPaginationInformationInHeader(result.ToMetaData());
        return Ok(result.Items);
    }
}
