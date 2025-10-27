using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Commands.CancelAppointment;

public class CancelAppointmentCommandHandler(IAppointmentRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CancelAppointmentCommand>
{
    public async Task Handle(CancelAppointmentCommand request)
    {
        Appointment appointment = await repository.GetById(request.Id) ?? throw new NotFoundException();
        appointment.Cancel();

		try
		{
			await repository.Update(appointment);
			await unitOfWork.Commit();
        }
		catch
		{
			await unitOfWork.Rollback();
            throw;
		}
    }
}
