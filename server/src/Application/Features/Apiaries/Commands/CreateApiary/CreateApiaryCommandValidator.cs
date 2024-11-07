namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;

using FluentValidation;
using static ApiaryManagementSystem.Domain.Constants.Models.Apiary;
using static ApiaryManagementSystem.Domain.Constants.Models.Common;

public class CreateApiaryCommandValidator : AbstractValidator<CreateApiaryCommand>
{
    public CreateApiaryCommandValidator()
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
