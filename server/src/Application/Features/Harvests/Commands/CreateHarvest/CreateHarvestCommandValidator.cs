namespace ApiaryManagementSystem.Application.Features.Harvests.Commands.CreateHarvest;

using FluentValidation;
using static Domain.Constants.Models.Harvest;

public class CreateHarvestCommandValidator : AbstractValidator<CreateHarvestCommand>
{
    public CreateHarvestCommandValidator()
    {
        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Amount)
            .LessThanOrEqualTo(AmountMaxValue)
            .NotEmpty();

        RuleFor(x => x.Product)
            .MinimumLength(HarvestedProductMinLength)
            .MaximumLength(HarvestedProductMaxLength)
            .NotEmpty();

        RuleFor(x => x.HiveId)
            .NotEmpty();
    }
}
