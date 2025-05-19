namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHives;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Hives.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

using static Common.Constants.ApplicationConstants.Pagination;

public sealed class GetHivesQuery : IRequest<PaginatedList<HiveModel>>
{
    public string? SearchTerm { get; init; }

    public int? Page { get; init; }

    public int? PageSize { get; init; }
}

internal sealed class GetHivesQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetHivesQuery, PaginatedList<HiveModel>>
{
    public async Task<PaginatedList<HiveModel>> Handle(GetHivesQuery request, CancellationToken cancellationToken)
    {
        int page = request.Page ?? DefaultPage;
        int pageSize = request.PageSize ?? DefaultPageSize;
        var searchTerm = request.SearchTerm;

        var hivesQuery = dbContext.Hives
            .Where(x => x.CreatedBy == user.Id)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            hivesQuery = hivesQuery.Where(x => (
                x.Number.Contains(searchTerm) ||
                x.Status.Contains(searchTerm) ||
                x.Type.Contains(searchTerm)) ||
                x.DateBought.ToString().Contains(searchTerm));
        }

        return await hivesQuery
            .ProjectTo<HiveModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync<HiveModel>(page, pageSize);
    }
}
