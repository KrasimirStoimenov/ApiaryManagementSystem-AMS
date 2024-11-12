using ApiaryManagementSystem.Application.Common.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById;

public sealed class GetHiveByIdQuery : IRequest<HiveModel>
{
    public required Guid HiveId { get; init; }
}

internal sealed class GetHiveByIdQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetHiveByIdQuery, HiveModel>
{
    public async Task<HiveModel> Handle(GetHiveByIdQuery request, CancellationToken cancellationToken)
    {
        var hive = await dbContext.Hives
            .Where(x => x.Id == request.HiveId)
            .AsNoTracking()
            .ProjectTo<HiveModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.HiveId, hive);

        return hive;
    }
}
