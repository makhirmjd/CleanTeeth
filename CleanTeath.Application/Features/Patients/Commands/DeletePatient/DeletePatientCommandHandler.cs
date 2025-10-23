using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePatientCommand>
{
    public async Task Handle(DeletePatientCommand request)
    {
        Patient patient = await repository.GetById(request.Id) ?? throw new NotFoundException();

        try
        {
            await repository.Delete(patient);
            await unitOfWork.Commit();
        }
        catch
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
