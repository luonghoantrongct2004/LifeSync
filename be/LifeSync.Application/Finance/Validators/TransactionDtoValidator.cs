using FluentValidation;
using LifeSync.Application.Finance.DTOs;
using Microsoft.Extensions.Localization;

namespace LifeSync.Application.Finance.Validators;

public class TransactionDtoValidator : AbstractValidator<TransactionDto>
{
    public TransactionDtoValidator(IStringLocalizer<TransactionDtoValidator> localizer)
    {
        RuleFor(x => x.Amount)
            .NotEqual(0).WithMessage(localizer["AmountNotZero"])
            .GreaterThan(-1000000000).WithMessage(localizer["AmountTooSmall"])
            .LessThan(1000000000).WithMessage(localizer["AmountTooLarge"]);
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(localizer["DescriptionRequired"])
            .MaximumLength(500).WithMessage(localizer["DescriptionMaxLength"]);
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage(localizer["CategoryRequired"])
            .MaximumLength(100).WithMessage(localizer["CategoryMaxLength"]);
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(localizer["DateNotFuture"]);
    }
} 