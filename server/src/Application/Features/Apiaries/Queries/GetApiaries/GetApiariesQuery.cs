namespace ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

using static ApiaryManagementSystem.Application.Common.Constants.ApplicationConstants.Pagination;

public sealed class GetApiariesQuery : IRequest<PaginatedList<ApiaryModel>>
{
    public int? Page { get; init; }

    public int? PageSize { get; init; }

    internal sealed class GetApiariesWithPaginationQueryHandler(
        IApplicationDbContext applicationDbContext,
        IMapper mapper) : IRequestHandler<GetApiariesQuery, PaginatedList<ApiaryModel>>
    {
        public async Task<PaginatedList<ApiaryModel>> Handle(GetApiariesQuery request, CancellationToken cancellationToken)
        {
            int page = request.Page ?? DefaultPage;
            int pageSize = request.PageSize ?? DefaultPageSize;

            return await applicationDbContext.Apiaries
                .AsNoTracking()
                .ProjectTo<ApiaryModel>(mapper.ConfigurationProvider)
                .ToPaginatedListAsync(page, pageSize);
        }
    }
}
