using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Notifications;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeath.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentCommandHandler(IAppointmentRepository repository, 
    IUnitOfWork unitOfWork, INotifications notifications) : IRequestHandler<CreateAppointmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAppointmentCommand request)
    {
        bool overlapExists = await repository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);

        if (overlapExists)
        {
            throw new CustomValidationException("The dentist has an appointment that overlaps");
        }

        TimeInterval timeInterval = new(request.StartDate, request.EndDate);
        Appointment appointment = new(request.PatientId, request.DentistId, request.DentalOfficeId, timeInterval);

        try
        {
            Appointment result = await repository.Add(appointment);
            await unitOfWork.Commit();
            await DispatchEmail(result);
            return result.Id;
        }
        catch
        {
            await unitOfWork.Rollback();
            throw;
        }
    }

    private async Task DispatchEmail(Appointment appointment)
    {
        try
        {
            await notifications.SendAppointmentConfirmation(appointment.ToDto());
        }
        catch
        {
        }
    }
}
