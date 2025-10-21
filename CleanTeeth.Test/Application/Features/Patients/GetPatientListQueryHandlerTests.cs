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
    }
}
