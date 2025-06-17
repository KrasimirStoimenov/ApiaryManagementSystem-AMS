namespace ApiaryManagementSystem.Application.Features.Diseases.Queries.GetDiseases;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Common.Mappings;
using ApiaryManagementSystem.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

public sealed class GetDiseasesQuery : IRequest<PaginatedList<DiseaseModel>>
{
    public required int Page { get; init; }

    public required int PageSize { get; init; }
}

internal sealed class GetDiseasesQueryHandler(
    IApplicationDbContext dbContext,
    IMapper mapper,
    IUser user) : IRequestHandler<GetDiseasesQuery, PaginatedList<DiseaseModel>>
{
    public async Task<PaginatedList<DiseaseModel>> Handle(GetDiseasesQuery request, CancellationToken cancellationToken)
        => await dbContext.Diseases
            .Where(x => x.CreatedBy == user.Id)
            .ProjectTo<DiseaseModel>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.Page, request.PageSize);
}
