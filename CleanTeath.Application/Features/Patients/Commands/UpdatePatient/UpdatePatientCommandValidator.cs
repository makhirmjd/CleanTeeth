using FluentValidation;

namespace CleanTeath.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("The field {PropertyName} is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}
