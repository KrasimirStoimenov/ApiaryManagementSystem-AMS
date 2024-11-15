namespace ApiaryManagementSystem.Application.Features.Inspections.Mapping;

using ApiaryManagementSystem.Domain.Models.Inspections;
using AutoMapper;

internal sealed class InspectionsMappingProfile : Profile
{
    public InspectionsMappingProfile()
        => CreateMap<Inspection, InspectionModel>()
            .ForMember(m => m.ColonyStrength, opts => opts.MapFrom(src => src.ColonyStrength.Name))
            .ForMember(m => m.FramesWithCappedBrood, opts => opts.MapFrom(src => src.FramesWithCappedBrood.Name))
            .ForMember(m => m.FramesWithUncappedBrood, opts => opts.MapFrom(src => src.FramesWithUncappedBrood.Name))
            .ForMember(m => m.FramesWithHoney, opts => opts.MapFrom(src => src.FramesWithHoney.Name))
            .ForMember(m => m.FramesWithPollen, opts => opts.MapFrom(src => src.FramesWithPollen.Name))
            .ForMember(m => m.FramesWithFreeSpace, opts => opts.MapFrom(src => src.FramesWithFreeSpace.Name))
            .ForMember(m => m.BroodPattern, opts => opts.MapFrom(src => src.BroodPattern.Name))
            .ForMember(m => m.BeeBehaviour, opts => opts.MapFrom(src => src.BeeBehaviour.Name))
            .ForMember(m => m.SwarmingState, opts => opts.MapFrom(src => src.SwarmingState.Name));
}
