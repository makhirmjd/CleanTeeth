using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Utilities.Mediator;

[TestClass]
public class SimpleMediatorTests
{
    public class FalseRequest : IRequest<string> { }

    [TestMethod]
    public async Task Send_WithRegisteredHandler_HandleIsExecuted()
    {
        var request = new FalseRequest();

        var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
        
        var serviceProvider = Substitute.For<IServiceProvider>();

        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .Returns(handlerMock);

        var mediator = new SimpleMediator(serviceProvider);

        string result = await mediator.Send(request);

        await handlerMock.Received(1).Handle(request);
    }

    [TestMethod]
    public async Task Send_WithoutRegisteredHandler_ThrowsMediatorException()
    {
        var request = new FalseRequest();
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .ReturnsNull();
        var mediator = new SimpleMediator(serviceProvider);
        Assert.Throws<MediatorException>(() => mediator.Send(request).GetAwaiter().GetResult());
    }
}
