using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Commands.CreateDentist;

public class CreateDentistCommandHandler(IDentistRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<CreateDentistCommand, Guid>
{
    public async Task<Guid> Handle(CreateDentistCommand request)
    {
        var dentist = new Dentist(request.Name, new(request.Email));

		try
		{
			Dentist result = await repository.Add(dentist);
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
