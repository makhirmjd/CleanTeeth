using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Commands.DeleteDentist;

public class DeleteDentistCommandHandler(IDentistRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDentistCommand>
{
    public async Task Handle(DeleteDentistCommand request)
    {
        Dentist dentist = await repository.GetById(request.Id) 
            ?? throw new NotFoundException();

		try
		{
			await repository.Delete(dentist);
			await unitOfWork.Commit();
        }
		catch
		{
			await unitOfWork.Rollback();
            throw;
		}
    }
}
