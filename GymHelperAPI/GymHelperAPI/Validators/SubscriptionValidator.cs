using System.Data;
using FluentValidation;
using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;

namespace GymHelperAPI.Validators;

public class SubscriptionValidator : AbstractValidator<SubscriptionDTO>
{
    public SubscriptionValidator()
    {
        RuleFor(p => p.Type).NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50)
            .Matches(@"([A-Z]|[А-Я]){1}([a-z]|[а-я])*");
        RuleFor(p => p.Description).MinimumLength(1)
            .NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
    }
}