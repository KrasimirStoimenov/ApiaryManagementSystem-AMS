namespace ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspectionById;

using ApiaryManagementSystem.Application.Common.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class GetInspectionByIdQuery : IRequest<InspectionModel>
{
    public required Guid InspectionId { get; init; }
}

internal sealed class GetInspectionByIdQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper) : IRequestHandler<GetInspectionByIdQuery, InspectionModel>
{
    public async Task<InspectionModel> Handle(GetInspectionByIdQuery request, CancellationToken cancellationToken)
    {
        var inspection = await dbContext.Inspections
            .Where(x => x.Id == request.InspectionId)
            .AsNoTracking()
            .ProjectTo<InspectionModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.InspectionId, inspection);

        return inspection;
    }
}
