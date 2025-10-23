using CleanTeath.Application.Features.Dentists.Commands.CreateDentist;
using CleanTeath.Application.Features.Dentists.Commands.DeleteDentist;
using CleanTeath.Application.Features.Dentists.Commands.UpdateDentist;
using CleanTeath.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeath.Application.Features.Dentists.Queries.GetDentistList;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.API.Dtos.Dentists;
using CleanTeeth.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentistsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetDentistsListQuery query)
    {
        var result = await mediator.Send(query);
        HttpContext.InsertPaginationInformationInHeader(result.ToMetaData());
        return Ok(result.Items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDentistDetailQuery { Id = id };
        DentistDetailDto result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDentistDto createDentistDto)
    {
        var command = new CreateDentistCommand
        {
            Name = createDentistDto.Name,
            Email = createDentistDto.Email
        };
        Guid id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateDentistDto updateDentistDto)
    {
        var command = new UpdateDentistCommand
        {
            Id = id,
            Name = updateDentistDto.Name,
            Email = updateDentistDto.Email
        };
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDentistCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}
