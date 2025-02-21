namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.UpdateInspection;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.Models;
using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Events.Inspections;
using ApiaryManagementSystem.Domain.Models.Inspections;
using Ardalis.GuardClauses;
using MediatR;

public sealed class UpdateInspectionCommand : IRequest
{
    public required Guid Id { get; init; }

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

internal sealed class UpdateInspectionCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateInspectionCommand>
{
    public async Task Handle(UpdateInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = await dbContext.Inspections
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, inspection);

        inspection.UpdateInspection(
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

        inspection.AddDomainEvent(new InspectionUpdatedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
