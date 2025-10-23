using FluentValidation;

namespace CleanTeath.Application.Features.Dentists.Commands.UpdateDentist;

public class UpdateDentistCommandValidator : AbstractValidator<UpdateDentistCommand>
{
    public UpdateDentistCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("The field {PropertyName} is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}
