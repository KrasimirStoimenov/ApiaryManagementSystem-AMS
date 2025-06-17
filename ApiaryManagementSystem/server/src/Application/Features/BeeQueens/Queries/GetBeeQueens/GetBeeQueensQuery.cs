namespace ApiaryManagementSystem.Application.Features.BeeQueens.Queries.GetBeeQueens;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

public sealed class GetBeeQueensQuery : IRequest<PaginatedList<BeeQueenModel>>
{
    public required int Page { get; init; }

    public required int PageSize { get; init; }
}

internal sealed class GetBeeQueensQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetBeeQueensQuery, PaginatedList<BeeQueenModel>>
{
    public async Task<PaginatedList<BeeQueenModel>> Handle(GetBeeQueensQuery request, CancellationToken cancellationToken)
        => await dbContext.BeeQueens
            .Where(x => x.CreatedBy == user.Id)
            .ProjectTo<BeeQueenModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.Page, request.PageSize);
}
