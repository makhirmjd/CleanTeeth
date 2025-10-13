using CleanTeath.Application.Exceptions;
using CleanTeath.Application.Utilities;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Tests.Application.Utilities.Mediator;

[TestClass]
public class SimpleMediatorTests
{
    public class FalseRequest : IRequest<string> 
    {
        public required string Name { get; set; }
    }

    public class FalseRequestValidator : AbstractValidator<FalseRequest>
    {
        public FalseRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    [TestMethod]
    public async Task Send_WithRegisteredHandler_HandleIsExecuted()
    {
        var request = new FalseRequest { Name = "Example" };

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
        var request = new FalseRequest { Name = "Example" };
        var serviceProvider = Substitute.For<IServiceProvider>();
        serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .ReturnsNull();
        var mediator = new SimpleMediator(serviceProvider);
        Assert.Throws<MediatorException>(() => mediator.Send(request).GetAwaiter().GetResult());
    }

    [TestMethod]
    public async Task Send_InvalidCommand_ThrowsCustomValidationException()
    {
        var request = new FalseRequest { Name = "" };
        var serviceProvider = Substitute.For<IServiceProvider>();
        var validator = new FalseRequestValidator();

        serviceProvider
            .GetService(typeof(IValidator<FalseRequest>))
            .Returns(validator);

        var mediator = new SimpleMediator(serviceProvider);

        Assert.Throws<CustomValidationException>(() => mediator.Send(request).GetAwaiter().GetResult());
    }
}
