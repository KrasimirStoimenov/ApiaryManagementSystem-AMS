namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHives;

using FluentValidation;

using static Common.Constants.ApplicationConstants.Pagination;

public class GetHivesQueryValidator : AbstractValidator<GetHivesQuery>
{
    public GetHivesQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(MinPage)
                .WithMessage($"Page should be greater than or equal to {MinPage}.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(MinPageSize)
                .WithMessage($"Page size should be greater than or equal to {MinPageSize}.")
            .LessThanOrEqualTo(MaxPageSize)
                .WithMessage($"Page size should be less than or equal to {MaxPageSize}.");
    }
}
