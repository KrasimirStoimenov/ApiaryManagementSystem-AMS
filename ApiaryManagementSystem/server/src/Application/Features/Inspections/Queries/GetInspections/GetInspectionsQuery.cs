namespace ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspections;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Inspections.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

public sealed class GetInspectionsQuery : IRequest<PaginatedList<InspectionModel>>
{
    public required int Page { get; init; }

    public required int PageSize { get; init; }
}

internal sealed class GetInspectionsQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetInspectionsQuery, PaginatedList<InspectionModel>>
{
    public async Task<PaginatedList<InspectionModel>> Handle(GetInspectionsQuery request, CancellationToken cancellationToken)
        => await dbContext.Inspections
            .Where(x => x.CreatedBy == user.Id)
            .ProjectTo<InspectionModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.Page, request.PageSize);
}
