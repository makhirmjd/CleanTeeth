using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeath.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(IPatientRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<UpdatePatientCommand>
{
    public async Task Handle(UpdatePatientCommand request)
    {
        Patient patient = await repository.GetById(request.Id)
            ?? throw new NotFoundException();

        patient.UpdateName(request.Name);
        patient.UpdateEmail(new Email(request.Email));

        try
        {
            await repository.Update(patient);
            await unitOfWork.Commit();
        }
        catch
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
