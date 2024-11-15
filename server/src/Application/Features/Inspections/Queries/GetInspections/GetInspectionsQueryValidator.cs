namespace ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspections;

using FluentValidation;

using static Common.Constants.ApplicationConstants.Pagination;

public class GetInspectionsQueryValidator : AbstractValidator<GetInspectionsQuery>
{
    public GetInspectionsQueryValidator()
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
