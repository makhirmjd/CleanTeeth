using CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeath.Application.Utilities;
using CleanTeeth.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentalOfficesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDentalOfficeDetailQuery { Id = id };
        DentalOfficeDetailDto result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDentalOfficeDto createDentalOfficeDto)
    {
        var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDto.Name};
        Guid id = await mediator.Send(command);
        return Ok(id);
    }
}
