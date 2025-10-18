using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class UpdateDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository = default!;
    private IUnitOfWork unitOfWork = default!;
    private UpdateDentalOfficeCommandHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        Guid id = dentalOffice.Id;
        var command = new UpdateDentalOfficeCommand
        {
            Id = id,
            Name = "New name"
        };

        repository.GetById(id).Returns(dentalOffice);
        await handler.Handle(command);

        await repository.Received(1).Update(dentalOffice);
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeDoesNotExist_ThrowsNotFoundException()
    {
        var command = new UpdateDentalOfficeCommand
        {
            Id = Guid.NewGuid(),
            Name = "New name"
        };
        repository.GetById(command.Id).ReturnsNull();
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command));
    }

    [TestMethod]
    public async Task Handle_WhenThereIsAnExceptionUpdating_RollbackIsCalled()
    {
        var dentalOffice = new DentalOffice("Dental Office 1");
        Guid id = dentalOffice.Id;
        var command = new UpdateDentalOfficeCommand
        {
            Id = id,
            Name = "New name"
        };

        repository.GetById(id).Returns(dentalOffice);
        repository.Update(dentalOffice).Throws(new InvalidOperationException("Exception"));

        await Assert.ThrowsAsync<InvalidOperationException>(() => handler.Handle(command));

        await unitOfWork.Received(1).Rollback();
    }
}
