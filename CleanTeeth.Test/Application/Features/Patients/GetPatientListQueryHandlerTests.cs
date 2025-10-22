using Bogus;
using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.Patients.Queries.GetPatientList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using NSubstitute;

namespace CleanTeeth.Tests.Application.Features.Patients;

[TestClass]
public class GetPatientListQueryHandlerTests
{
    private IPatientRepository repository = default!;
    private GetPatientsListQueryHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IPatientRepository>();
        handler = new GetPatientsListQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_ValidRequest_ReturnsPatientList()
    {
        var query = new GetPatientsListQuery { Page = 1, RecordsPerPage = 2 };
        IEnumerable<Patient> patients = new Faker<Patient>()
            .CustomInstantiator(f =>
            {
                string name = f.Name.FullName();
                Email email = new(f.Internet.Email(name));
                return new(name, email);
            }).Generate(10);

        repository.GetFiltered(Arg.Any<PatientsFilterDto>()).Returns(Task.FromResult(patients));
        repository.GetTotalAmountOfRecords().Returns(Task.FromResult(50));
        var result = await handler.Handle(query);
        Assert.AreEqual(50, result.ToMetaData().TotalAmountOfRecords);
        Assert.HasCount(10, result.Items);
    }

    [TestMethod]
    public async Task Handle_WhenThereAreNoPatients_ReturnsEmptyListAndZero()
    {
        IEnumerable<Patient> patients = [];
        repository.GetFiltered(Arg.Any<PatientsFilterDto>()).Returns(Task.FromResult(patients));
        repository.GetTotalAmountOfRecords().Returns(Task.FromResult(0));
        var query = new GetPatientsListQuery { Page = 1, RecordsPerPage = 5 };
        var result = await handler.Handle(query);
        Assert.AreEqual(0, result.ToMetaData().TotalAmountOfRecords);
        Assert.IsNotNull(result.Items);
        Assert.HasCount(0, result.Items);
    }
}
