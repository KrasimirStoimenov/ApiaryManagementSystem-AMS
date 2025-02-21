namespace ApiaryManagementSystem.Application.Features.Diseases.Mapping;

using ApiaryManagementSystem.Application.Features.Diseases.Queries;
using ApiaryManagementSystem.Domain.Models.Diseases;
using AutoMapper;

internal sealed class DiseasesMappingProfile : Profile
{
    public DiseasesMappingProfile()
        => this.CreateMap<Disease, DiseaseModel>();
}
