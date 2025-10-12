namespace CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command, CancellationToken cancellationToken)
    {
        // Implementation for creating a dental office
        // This is a placeholder implementation
        await Task.Delay(100, cancellationToken); // Simulate async work
        return Guid.NewGuid(); // Return a new GUID as the ID of the created dental office
    }
}
