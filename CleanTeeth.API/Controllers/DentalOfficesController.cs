using CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeath.Application.Utilities;
using CleanTeeth.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentalOfficesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateDentalOfficeDto createDentalOfficeDto)
    {
        var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDto.Name};
        Guid id = await mediator.Send(command);
        return Ok(id);
    }
}
