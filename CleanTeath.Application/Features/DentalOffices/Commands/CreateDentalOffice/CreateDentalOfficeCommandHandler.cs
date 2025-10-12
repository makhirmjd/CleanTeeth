using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
        DentalOffice dentalOffice = new(command.Name);
		try
		{
            DentalOffice result = await repository.Add(dentalOffice);
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
