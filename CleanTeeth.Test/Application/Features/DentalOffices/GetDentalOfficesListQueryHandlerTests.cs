using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Domain.Entities;
using NSubstitute;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficesListQueryHandlerTests
{
    private IDentalOfficeRepository repository =  default!;
    private GetDentalOfficesListQueryHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        handler = new(repository);
    }

    [TestMethod]
    public async Task Handle_WhenThereAreDentalOffices_ReturnsListOfThem()
    {
        List<DentalOffice> dentalOffices = [new("Dental Office A"), new("Dental Office B")];
        repository.GetAll().Returns(dentalOffices);
        var expected = dentalOffices.Select(d => new DentalOfficesListDto
        { 
            Id = d.Id, 
            Name = d.Name 
        }).ToList();

        var result = await handler.Handle(new GetDentalOfficesListQuery());

        Assert.HasCount(expected.Count, result);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.AreEqual(expected[i].Id, result[i].Id);
            Assert.AreEqual(expected[i].Name, result[i].Name);
        }
    }

    [TestMethod]
    public async Task Handle_WhenThereAreNoDentalOffices_ItReturnsAnEmptyList()
    {
        repository.GetAll().Returns([]);
        var result = await handler.Handle(new GetDentalOfficesListQuery());
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }
}
