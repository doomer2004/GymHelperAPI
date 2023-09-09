using FluentValidation;
using GymAPI.Common.DTO;

namespace GymHelperAPI.Validators;

public class UpdateSubscriptionValidator : AbstractValidator<UpdateSubscriptionDTO>
{
    public UpdateSubscriptionValidator()
    {
        RuleFor(p => p.Type).MinimumLength(1)
            .NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
    }
}