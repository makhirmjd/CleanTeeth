using FluentValidation;

namespace CleanTeath.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The field {PropertyName} is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}
