﻿namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Hives.Queries;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
