namespace ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaryById;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries;
using Ardalis.GuardClauses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class GetApiaryByIdQuery : IRequest<ApiaryModel>
{
    public Guid ApiaryId { get; init; }

    internal sealed class GetApiaryByIdQueryHandler(
        IApplicationDbContext dbContext,
        IMapper mapper) : IRequestHandler<GetApiaryByIdQuery, ApiaryModel>
    {
        public async Task<ApiaryModel> Handle(GetApiaryByIdQuery request, CancellationToken cancellationToken)
        {
            var apiary = await dbContext.Apiaries
                .Where(x => x.Id == request.ApiaryId)
                .AsNoTracking()
                .ProjectTo<ApiaryModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            Guard.Against.NotFound(request.ApiaryId, apiary);

            return apiary;
        }
    }
}
