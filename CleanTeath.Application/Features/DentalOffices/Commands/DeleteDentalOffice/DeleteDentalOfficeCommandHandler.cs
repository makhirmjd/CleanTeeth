using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities.Mediator;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Commands.DeleteDentalOffice;

public class DeleteDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteDentalOfficeCommand>
{
    public async Task Handle(DeleteDentalOfficeCommand request)
    {
        DentalOffice dentalOffice = await  repository.GetById(request.Id) ?? throw new NotFoundException();

		try
		{
			await repository.Delete(dentalOffice);
			await unitOfWork.Commit();
        }
		catch
		{
			await unitOfWork.Rollback();
            throw;
		}
    }
}
