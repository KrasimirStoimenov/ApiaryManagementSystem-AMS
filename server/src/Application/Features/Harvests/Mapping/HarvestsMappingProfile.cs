namespace ApiaryManagementSystem.Application.Features.Harvests.Mapping;

using ApiaryManagementSystem.Application.Features.Harvests.Queries;
using ApiaryManagementSystem.Domain.Models.Harvests;
using AutoMapper;

internal sealed class HarvestsMappingProfile : Profile
{
    public HarvestsMappingProfile()
        => this.CreateMap<Harvest, HarvestModel>();
}
