using FluentValidation;

namespace Tripify.Application.Trips.Commands.CreateTrip;

public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
{
    public CreateTripCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(x => x.Destination)
            .NotEmpty().WithMessage("Destination is required")
            .MaximumLength(200).WithMessage("Destination must not exceed 200 characters");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required")
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date must be today or in the future");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date");

        RuleFor(x => x.Budget)
            .GreaterThanOrEqualTo(0).WithMessage("Budget must be greater than or equal to 0");
    }
}
