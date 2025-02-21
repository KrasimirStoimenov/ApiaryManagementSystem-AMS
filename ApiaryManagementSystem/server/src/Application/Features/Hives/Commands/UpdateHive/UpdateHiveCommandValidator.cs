namespace ApiaryManagementSystem.Application.Features.Hives.Commands.UpdateHive;

using FluentValidation;

using static ApiaryManagementSystem.Domain.Constants.Models.Hive;

public class UpdateHiveCommandValidator : AbstractValidator<UpdateHiveCommand>
{
    public UpdateHiveCommandValidator()
    {
        RuleFor(x => x.Number)
            .MinimumLength(NumberMinLength)
            .MaximumLength(NumberMaxLength)
            .NotEmpty();

        RuleFor(x => x.Type)
            .MinimumLength(TypeMinLength)
            .MaximumLength(TypeMaxLength)
            .NotEmpty();

        RuleFor(x => x.Status)
            .MinimumLength(StatusMinLength)
            .MaximumLength(StatusMaxLength)
            .NotEmpty();

        RuleFor(x => x.Color)
            .MaximumLength(ColorMaxLength);

        RuleFor(x => x.DateBought)
            .NotEmpty();

        RuleFor(x => x.ApiaryId)
            .NotEmpty();
    }
}
