namespace ApiaryManagementSystem.Application.Features.Harvests.Queries.GetHarvests;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

public sealed class GetHarvestsQuery : IRequest<PaginatedList<HarvestModel>>
{
    public required int Page { get; init; }

    public required int PageSize { get; init; }
}

internal sealed class GetHarvestsQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetHarvestsQuery, PaginatedList<HarvestModel>>
{
    public async Task<PaginatedList<HarvestModel>> Handle(GetHarvestsQuery request, CancellationToken cancellationToken)
        => await dbContext.Harvests
            .Where(x => x.CreatedBy == user.Id)
            .ProjectTo<HarvestModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.Page, request.PageSize);
}
