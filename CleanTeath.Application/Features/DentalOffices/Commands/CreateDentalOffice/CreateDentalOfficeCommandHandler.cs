using CleanTeath.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;

namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository)
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
        DentalOffice dentalOffice = new(command.Name);
        DentalOffice result = await repository.Add(dentalOffice);
        return result.Id;
    }
}
