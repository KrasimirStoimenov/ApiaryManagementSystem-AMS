namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHivesByApiaryId;

using ApiaryManagementSystem.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class GetHivesByApiaryIdQuery : IRequest<IReadOnlyCollection<HiveModel>>
{
    public required Guid ApiaryId { get; init; }

    internal sealed class GetHivesByApiaryIdQueryHandler(
        IApplicationDbContext dbContext,
        IMapper mapper) : IRequestHandler<GetHivesByApiaryIdQuery, IReadOnlyCollection<HiveModel>>
    {
        public async Task<IReadOnlyCollection<HiveModel>> Handle(GetHivesByApiaryIdQuery request, CancellationToken cancellationToken)
        {
            //TODO: Check if all properties from HiveModel are needed. If not introduce another model which contains only needed properties.
            var hives = await dbContext.Hives
                .Where(x => x.ApiaryId == request.ApiaryId)
                .AsNoTracking()
                .ProjectTo<HiveModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return hives;
        }
    }
}
