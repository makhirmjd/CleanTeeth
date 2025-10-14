using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class CreateDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository = default!;
    private IUnitOfWork unitOfWork = default!;
    private CreateDentalOfficeCommandHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new CreateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_ReturnsDentalOfficeId()
    {
        var command = new CreateDentalOfficeCommand { Name = "Dental Office A"};
        var dentalOffice = new DentalOffice(command.Name);
        repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

        Guid result = await handler.Handle(command);

        await repository.Received(1).Add(Arg.Any<DentalOffice>());
        await unitOfWork.Received(1).Commit();
        Assert.AreEqual(dentalOffice.Id, result);
    }

    [TestMethod]
    public async Task Handle_WhenRepositoryThrows_ExceptionIsRethrownAndRollbackCalled()
    {
        var command = new CreateDentalOfficeCommand { Name = "Dental Office A"};
        var expectedException = new InvalidOperationException("Database error");
        repository.Add(Arg.Any<DentalOffice>()).Throws(expectedException);

        Exception actualException = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command));

        await unitOfWork.Received(1).Rollback();
        await unitOfWork.DidNotReceive().Commit();
        Assert.AreSame(expectedException, actualException);
    }
}
