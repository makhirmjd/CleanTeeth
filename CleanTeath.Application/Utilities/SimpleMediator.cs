
using CleanTeath.Application.Exceptions;
using System.Reflection;

namespace CleanTeath.Application.Utilities;

public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        object handler = 
            serviceProvider.GetService(handlerType) ?? 
            throw new MediatorException($"Handler was not found for {request.GetType().Name}");
        MethodInfo method = handlerType.GetMethod("Handle") ?? throw new MediatorException("Handle method was not found");
        return await (Task<TResponse>)method.Invoke(handler, [request])!;
    }
}
