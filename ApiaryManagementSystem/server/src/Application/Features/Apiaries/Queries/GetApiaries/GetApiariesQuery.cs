namespace ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

public sealed class GetApiariesQuery : IRequest<PaginatedList<ApiaryModel>>
{
    public string? SearchTerm { get; init; }

    public required int Page { get; init; } = 1;

    public required int PageSize { get; init; } = 10;
}

internal sealed class GetApiariesWithPaginationQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetApiariesQuery, PaginatedList<ApiaryModel>>
{
    public async Task<PaginatedList<ApiaryModel>> Handle(GetApiariesQuery request, CancellationToken cancellationToken)
    {
        var apiariesQuery = dbContext.Apiaries
            .Where(x => x.CreatedBy == user.Id)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            apiariesQuery = apiariesQuery.Where(x =>
                (x.Name.Contains(request.SearchTerm) || x.Location.Contains(request.SearchTerm)));
        }

        return await apiariesQuery
            .ProjectTo<ApiaryModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.Page, request.PageSize);
    }
}

