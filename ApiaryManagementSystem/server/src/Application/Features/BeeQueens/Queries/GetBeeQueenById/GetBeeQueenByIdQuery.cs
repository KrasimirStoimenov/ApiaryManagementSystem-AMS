namespace ApiaryManagementSystem.Application.Features.BeeQueens.Queries.GetBeeQueenById;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class GetBeeQueenByIdQuery : IRequest<BeeQueenModel>
{
    public Guid BeeQueenId { get; init; }
}

internal sealed class GetBeeQueenByIdQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetBeeQueenByIdQuery, BeeQueenModel>
{
    public async Task<BeeQueenModel> Handle(GetBeeQueenByIdQuery request, CancellationToken cancellationToken)
    {
        var beeQueen = await dbContext.BeeQueens
            .Where(x => x.Id == request.BeeQueenId)
            .AsNoTracking()
            .ProjectTo<BeeQueenModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.BeeQueenId, beeQueen);

        return beeQueen;
    }
}
