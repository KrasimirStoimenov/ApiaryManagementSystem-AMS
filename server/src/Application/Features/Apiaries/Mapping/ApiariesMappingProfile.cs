namespace ApiaryManagementSystem.Application.Features.Apiaries.Mapping;

using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries.Models;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using AutoMapper;

internal sealed class ApiariesMappingProfile : Profile
{
    public ApiariesMappingProfile()
        => this.CreateMap<Apiary, ApiaryModel>();
}
