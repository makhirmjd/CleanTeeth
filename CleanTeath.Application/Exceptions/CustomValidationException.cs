using FluentValidation.Results;

namespace CleanTeath.Application.Exceptions;

public class CustomValidationException : Exception
{
    public List<string> ValidationErrors { get; set; } = [];

    public CustomValidationException(string errorMessage)
    {
        ValidationErrors.Add(errorMessage);
    }

    public CustomValidationException(ValidationResult validationResult)
    {
        ValidationErrors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
    }
}
