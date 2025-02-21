namespace ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspections;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Inspections.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using static Common.Constants.ApplicationConstants.Pagination;

public sealed class GetInspectionsQuery : IRequest<PaginatedList<InspectionModel>>
{
    public int? Page { get; init; }

    public int? PageSize { get; init; }
}

internal sealed class GetInspectionsQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetInspectionsQuery, PaginatedList<InspectionModel>>
{
    public async Task<PaginatedList<InspectionModel>> Handle(GetInspectionsQuery request, CancellationToken cancellationToken)
    {
        int page = request.Page ?? DefaultPage;
        int pageSize = request.PageSize ?? DefaultPageSize;

        return await dbContext.Inspections
            .ProjectTo<InspectionModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(page, pageSize);
    }
}
