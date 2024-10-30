namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;

using static ApiaryManagementSystem.Domain.Models.ModelConstants.Apiary;
using static ApiaryManagementSystem.Domain.Models.ModelConstants.Common;

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
