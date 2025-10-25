using CleanTeath.Application.Features.Appointments.Commands.CreateAppointment;
using CleanTeath.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.API.Dtos.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        GetAppointmentDetailQuery query = new() { Id = id };
        var appointment = await mediator.Send(query);
        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAppointmentDto createAppointmentDto)
    {
        CreateAppointmentCommand command = new()
        {
            PatientId = createAppointmentDto.PatientId,
            DentistId = createAppointmentDto.DentistId,
            DentalOfficeId = createAppointmentDto.DentalOfficeId,
            StartDate = createAppointmentDto.StartDate,
            EndDate = createAppointmentDto.EndDate
        };
        Guid id = await mediator.Send(command);
        return Ok(id);
    }
}
