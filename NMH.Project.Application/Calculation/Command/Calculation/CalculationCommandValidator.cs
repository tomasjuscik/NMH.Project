using FluentValidation;

namespace NMH.Project.Application.Calculation.Command.Calculation;

public sealed class CalculationCommandValidator : AbstractValidator<CalculationCommand>
{
    public CalculationCommandValidator()
    {
        RuleFor(u => u.Input).NotEmpty().WithMessage("Input cannot be empty.");
    }
}