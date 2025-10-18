using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Commands.UpdateDentalOffice;

public class UpdateDentalOfficeCommandHandler(IDentalOfficeRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateDentalOfficeCommand>
{
    public async Task Handle(UpdateDentalOfficeCommand request)
    {
        DentalOffice? dentalOffice = await repository.GetById(request.Id);
        if (dentalOffice is null)
        {
            throw new NotFoundException();
        }

        dentalOffice.UpdateName(request.Name);

        try
        {
            await repository.Update(dentalOffice);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }
    }
}
