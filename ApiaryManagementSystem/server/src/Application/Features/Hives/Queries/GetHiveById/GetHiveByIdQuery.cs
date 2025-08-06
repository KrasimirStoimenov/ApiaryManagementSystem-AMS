namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById.Models;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class GetHiveByIdQuery : IRequest<HiveWithEnrichedDetailsModel>
{
    public required Guid HiveId { get; init; }
}

internal sealed class GetHiveByIdQueryHandler(
    IApplicationDbContext dbContext) : IRequestHandler<GetHiveByIdQuery, HiveWithEnrichedDetailsModel>
{
    public async Task<HiveWithEnrichedDetailsModel> Handle(GetHiveByIdQuery request, CancellationToken cancellationToken)
    {
        var hive = await dbContext.Hives
            .Where(x => x.Id == request.HiveId)
            .AsNoTracking()
            .Select(x => new HiveWithEnrichedDetailsModel(
                x.Id,
                x.Number,
                x.Type,
                x.Status,
                x.Color,
                x.DateBought,
                x.Apiary.Name,
                x.Apiary.Location,
                x.Inspections.Count,
                x.Harvests.Count,
                x.Diseases.Count))
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.HiveId, hive);

        return hive;
    }
}
