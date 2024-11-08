namespace ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries;

using FluentValidation;

public class GetApiariesQueryValidator : AbstractValidator<GetApiariesQuery>
{
    public GetApiariesQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1).WithMessage("Page should be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("Page size should be greater than or equal to 1.")
            .LessThanOrEqualTo(100).WithMessage("Page size should be less than or equal to 100.");
    }
}
