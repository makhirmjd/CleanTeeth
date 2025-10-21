using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeath.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork) : 
    IRequestHandler<CreatePatientCommand, Guid>
{
    public async Task<Guid> Handle(CreatePatientCommand request)
    {
        var email = new Email(request.Email);
        var patient = new Patient(request.Name, email);

		try
		{
			Patient result = await repository.Add(patient);
			await unitOfWork.Commit();
			return result.Id;
        }
		catch
		{
			await unitOfWork.Rollback();
            throw;
		}
    }
}
