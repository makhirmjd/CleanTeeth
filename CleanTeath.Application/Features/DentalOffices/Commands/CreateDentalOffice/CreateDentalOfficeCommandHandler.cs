using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities;
using CleanTeeth.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository, 
    IUnitOfWork unitOfWork, 
    IValidator<CreateDentalOfficeCommand> validator) : IRequestHandler<CreateDentalOfficeCommand, Guid>
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command)
    {
        ValidationResult validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new CustomValidationException(validationResult);
        }

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
