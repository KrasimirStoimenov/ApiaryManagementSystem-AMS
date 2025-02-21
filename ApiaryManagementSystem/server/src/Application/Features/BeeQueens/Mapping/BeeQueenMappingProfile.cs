namespace ApiaryManagementSystem.Application.Features.BeeQueens.Mapping;

using ApiaryManagementSystem.Application.Features.BeeQueens.Queries;
using ApiaryManagementSystem.Domain.Models.BeeQueens;
using AutoMapper;

internal sealed class BeeQueenMappingProfile : Profile
{
    public BeeQueenMappingProfile()
        => this.CreateMap<BeeQueen, BeeQueenModel>();
}
