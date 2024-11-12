namespace ApiaryManagementSystem.Application.Features.Hives.Mapping;

using ApiaryManagementSystem.Domain.Models.Hives;
using AutoMapper;

internal sealed class HivesMappingProfile : Profile
{
    public HivesMappingProfile()
        => CreateMap<Hive, HiveModel>();
}
