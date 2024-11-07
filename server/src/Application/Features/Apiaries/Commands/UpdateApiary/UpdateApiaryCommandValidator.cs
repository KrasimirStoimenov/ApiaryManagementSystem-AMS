namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.UpdateApiary;

using FluentValidation;
using static ApiaryManagementSystem.Domain.Constants.Models.Apiary;
using static ApiaryManagementSystem.Domain.Constants.Models.Common;

public class UpdateApiaryCommandValidator : AbstractValidator<UpdateApiaryCommand>
{
    public UpdateApiaryCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(NameMinLength)
            .MaximumLength(NameMaxLength)
            .NotEmpty();

        RuleFor(x => x.Location)
            .MinimumLength(LocationMinLength)
            .MaximumLength(LocationMaxLength)
            .NotEmpty();
    }
}
