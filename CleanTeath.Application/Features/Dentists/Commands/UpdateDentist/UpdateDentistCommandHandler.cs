using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.Dentists.Commands.UpdateDentist;

public class UpdateDentistCommandHandler(IDentistRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateDentistCommand>
{
    public async Task Handle(UpdateDentistCommand request)
    {
        Dentist dentist = await repository.GetById(request.Id) ?? throw new NotFoundException();
		dentist.UpdateName(request.Name);
        dentist.UpdateEmail(new(request.Email));

        try
		{
			await repository.Update(dentist);
			await unitOfWork.Commit();
        }
		catch
		{
			await unitOfWork.Rollback();
            throw;
		}
    }
}
