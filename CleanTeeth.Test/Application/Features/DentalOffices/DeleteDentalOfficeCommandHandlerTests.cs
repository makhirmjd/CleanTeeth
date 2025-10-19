using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class DeleteDentalOfficeCommandHandlerTests
{
    private IDentalOfficeRepository repository = default!;
    private IUnitOfWork unitOfWork = default!;
    private DeleteDentalOfficeCommandHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new DeleteDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExists_DeleteAndCommitAreCalled()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var command = new DeleteDentalOfficeCommand { Id = dentalOffice.Id };

        repository.GetById(command.Id).Returns(dentalOffice);

        await handler.Handle(command);

        await repository.Received(1).Delete(dentalOffice);
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeDoesNotExists_ThrowNotFoundException()
    {
        var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
        repository.GetById(command.Id).ReturnsNull();
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command));
        await repository.DidNotReceive().Delete(Arg.Any<DentalOffice>());
        await unitOfWork.DidNotReceive().Commit();
    }

    [TestMethod]
    public async Task Handle_WhenAnExceptionOccursWhileDeleting_RollbackIsCalled()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var command = new DeleteDentalOfficeCommand { Id = dentalOffice.Id };
        repository.GetById(command.Id).Returns(dentalOffice);
        repository.Delete(dentalOffice).Throws(new Exception("Database error"));
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command));
        await unitOfWork.Received(1).Rollback();

    }
}
