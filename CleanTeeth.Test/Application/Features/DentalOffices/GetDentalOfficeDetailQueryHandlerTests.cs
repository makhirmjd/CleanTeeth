using CleanTeath.Application.Contracts.Repositories;
using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficeDetailQueryHandlerTests
{
    private IDentalOfficeRepository repository = default!;
    private GetDentalOfficeDetailQueryHandler handler = default!;

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        handler = new GetDentalOfficeDetailQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeExists_ReturnsIt()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        Guid id = dentalOffice.Id;
        var query = new GetDentalOfficeDetailQuery { Id = id };

        repository.GetById(id).Returns(dentalOffice);

        DentalOfficeDetailDto result = await handler.Handle(query);

        Assert.IsNotNull(result);
        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(dentalOffice.Name, result.Name);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeDoesNotExist_ThrowsNotFoundException()
    {
        Guid id = Guid.NewGuid();
        var query = new GetDentalOfficeDetailQuery { Id = id };

        repository.GetById(id).ReturnsNull();

        await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(query));
    }
}
