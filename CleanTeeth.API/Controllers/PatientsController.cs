using CleanTeath.Application.Features.Patients.Commands.CreatePatient;
using CleanTeath.Application.Features.Patients.Commands.UpdatePatient;
using CleanTeath.Application.Features.Patients.Queries.GetPatientDetail;
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
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPatientsListQuery query)
    {
        var result = await mediator.Send(query);
        HttpContext.InsertPaginationInformationInHeader(result.ToMetaData());
        return Ok(result.Items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetPatientDetailQuery { Id = id };
        PatientDetailDto result = await mediator.Send(query);
        return Ok(result);
    }

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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdatePatientDto updatePatientDto)
    {
        var command = new UpdatePatientCommand
        {
            Id = id,
            Name = updatePatientDto.Name,
            Email = updatePatientDto.Email
        };
        await mediator.Send(command);
        return NoContent();
    }
}
