namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection.Models;
using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Events.Inspections;
using ApiaryManagementSystem.Domain.Models.Inspections;
using MediatR;

public sealed class CreateInspectionCommand : IRequest<Guid>
{
    public DateTime InspectionDate { get; init; }

    public ColonyStrengthRequestEnum ColonyStrength { get; init; }

    public FramesRequestEnum FramesWithCappedBrood { get; init; }

    public FramesRequestEnum FramesWithUncappedBrood { get; init; }

    public FramesRequestEnum FramesWithHoney { get; init; }

    public FramesRequestEnum FramesWithPollen { get; init; }

    public FramesRequestEnum FramesWithFreeSpace { get; init; }

    public BroodPatternRequestEnum BroodPattern { get; init; }

    public BeeBehaviourRequestEnum BeeBehaviour { get; init; }

    public SwarmingStateRequestEnum SwarmingState { get; init; }

    public bool IsQueenPresent { get; init; }

    public bool AreEggsPresent { get; init; }

    public bool AreQueenCellsPresent { get; init; }

    public bool AreDroneCellsPresent { get; init; }

    public string? Notes { get; init; }

    public required Guid HiveId { get; init; }
}

internal sealed class CreateInspectionCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateInspectionCommand, Guid>
{
    public async Task<Guid> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = new Inspection(
            request.InspectionDate,
            Enumeration.FromValue<ColonyStrength>((int)request.ColonyStrength),
            Enumeration.FromValue<Frames>((int)request.FramesWithCappedBrood),
            Enumeration.FromValue<Frames>((int)request.FramesWithUncappedBrood),
            Enumeration.FromValue<Frames>((int)request.FramesWithHoney),
            Enumeration.FromValue<Frames>((int)request.FramesWithPollen),
            Enumeration.FromValue<Frames>((int)request.FramesWithFreeSpace),
            Enumeration.FromValue<BroodPattern>((int)request.BroodPattern),
            Enumeration.FromValue<BeeBehaviour>((int)request.BeeBehaviour),
            Enumeration.FromValue<SwarmingState>((int)request.SwarmingState),
            request.IsQueenPresent,
            request.AreEggsPresent,
            request.AreQueenCellsPresent,
            request.AreDroneCellsPresent,
            request.Notes,
            request.HiveId);

        dbContext.Inspections.Add(inspection);

        inspection.AddDomainEvent(new InspectionCreatedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);

        return inspection.Id;
    }
}
