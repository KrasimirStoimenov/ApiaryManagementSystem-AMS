namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHives;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using static Common.Constants.ApplicationConstants.Pagination;

public sealed class GetHivesQuery : IRequest<PaginatedList<HiveModel>>
{
    public int? Page { get; init; }

    public int? PageSize { get; init; }
}

internal sealed class GetHivesQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetHivesQuery, PaginatedList<HiveModel>>
{
    public async Task<PaginatedList<HiveModel>> Handle(GetHivesQuery request, CancellationToken cancellationToken)
    {
        int page = request.Page ?? DefaultPage;
        int pageSize = request.PageSize ?? DefaultPageSize;

        return await dbContext.Hives
            .AsNoTracking()
            .ProjectTo<HiveModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync<HiveModel>(page, pageSize);
    }
}
