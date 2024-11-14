using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Inspections;
using ApiaryManagementSystem.Domain.Models.Inspections;
using MediatR;

namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;

public sealed class CreateInspectionCommand : IRequest<Guid>
{
    public DateTime InspectionDate { get; init; }

    public required ColonyStrength ColonyStrength { get; init; }

    public required Frames FramesWithCappedBrood { get; init; }

    public required Frames FramesWithUncappedBrood { get; init; }

    public required Frames FramesWithHoney { get; init; }

    public required Frames FramesWithPollen { get; init; }

    public required Frames FramesWithFreeSpace { get; init; }

    public required BroodPattern BroodPattern { get; init; }

    public required BeeBehaviour BeeBehaviour { get; init; }

    public required SwarmingState SwarmingState { get; init; }

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
            request.ColonyStrength,
            request.FramesWithCappedBrood,
            request.FramesWithUncappedBrood,
            request.FramesWithHoney,
            request.FramesWithPollen,
            request.FramesWithFreeSpace,
            request.BroodPattern,
            request.BeeBehaviour,
            request.SwarmingState,
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
