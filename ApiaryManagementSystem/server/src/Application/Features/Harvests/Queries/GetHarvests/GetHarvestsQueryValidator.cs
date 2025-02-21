namespace ApiaryManagementSystem.Application.Features.Harvests.Queries.GetHarvests;

using FluentValidation;
using static ApiaryManagementSystem.Application.Common.Constants.ApplicationConstants.Pagination;

public class GetHarvestsQueryValidator : AbstractValidator<GetHarvestsQuery>
{
    public GetHarvestsQueryValidator()
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
