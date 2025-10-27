using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Appointments.Commands.CompleteAppointment;

public class CompleteAppointmentCommandHandler(IAppointmentRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<CompleteAppointmentCommand>
{
    public async Task Handle(CompleteAppointmentCommand request)
    {
        Appointment appointment = await repository.GetById(request.Id) ?? throw new NotFoundException();
		appointment.Complete();

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
