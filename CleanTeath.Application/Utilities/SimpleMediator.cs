
using CleanTeath.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

namespace CleanTeath.Application.Utilities;

public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        await ApplyValidations(request);

        Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        object handler = 
            serviceProvider.GetService(handlerType) ?? 
            throw new MediatorException($"Handler was not found for {request.GetType().Name}");
        MethodInfo method = handlerType.GetMethod("Handle") ?? throw new MediatorException("Handle method was not found");
        return await (Task<TResponse>)method.Invoke(handler, [request])!;
    }

    public async Task Send(IRequest request)
    {
        await ApplyValidations(request);

        Type handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
        object handler =
            serviceProvider.GetService(handlerType) ??
            throw new MediatorException($"Handler was not found for {request.GetType().Name}");
        MethodInfo method = handlerType.GetMethod("Handle") ?? throw new MediatorException("Handle method was not found");
        await (Task)method.Invoke(handler, [request])!;
    }

    private async Task ApplyValidations(object request)
    {
        Type validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        object? validator = serviceProvider.GetService(validatorType);

        if (validator is not null)
        {
            MethodInfo? validateMethod = validatorType.GetMethod("ValidateAsync");

            if (validateMethod is not null)
            {
                Task taskToValidate = (Task)validateMethod.Invoke(validator, [request, CancellationToken.None])!;
                await taskToValidate;
                PropertyInfo? result = taskToValidate.GetType().GetProperty("Result");
                if (result is not null)
                {
                    ValidationResult validationResult = (ValidationResult)result.GetValue(taskToValidate)!;
                    if (!validationResult.IsValid)
                    {
                        throw new CustomValidationException(validationResult);
                    }
                }
            }
        }
    }
}
