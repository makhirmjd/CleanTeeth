using CleanTeath.Application.Contracts.Persistence;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.Patients.Commands.CreatePatient;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Tests.Application.Features.Patients;

[TestClass]
public class CreatePatientCommandHandlerTests
{
    public IPatientRepository repository = default!;
    public IUnitOfWork unitOfWork = default!;
    private CreatePatientCommandHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IPatientRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new CreatePatientCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_ReturnsPatientId()
    {
        var command = new CreatePatientCommand { Name = "test", Email = "test@example.com"};
        var patient = new Patient(command.Name, new Email(command.Email));

        repository.Add(Arg.Any<Patient>()).Returns(patient);

        var result = await handler.Handle(command);

        Assert.AreEqual(patient.Id, result);
        await repository.Received(1).Add(Arg.Any<Patient>());
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenThereIsAnError_WeRollback()
    {
        var command = new CreatePatientCommand { Name = "test", Email = "test@example.com" };
        repository.Add(Arg.Any<Patient>()).Throws<Exception>();

        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command));

        await unitOfWork.Received(1).Rollback();
    }
}
