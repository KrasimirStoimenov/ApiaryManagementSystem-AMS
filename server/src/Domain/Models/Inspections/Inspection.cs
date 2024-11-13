using ApiaryManagementSystem.Domain.Common;

namespace ApiaryManagementSystem.Domain.Models.Inspections;

public sealed class Inspection : BaseAuditableEntity
{
    public DateTime InspectionDate { get; init; }

    public required ColonyStrength ColonyStrength { get; init; }

    public required Frames CappedBrood { get; init; }

    public required Frames UncappedBrood { get; init; }

    public required Frames WithHoney { get; init; }

    public required Frames FullWithHoney { get; init; }

    public required Frames WithPollen { get; init; }

    public required Frames WithFreeSpace { get; init; }

    public required BroodPattern BroodPattern { get; init; }

    public required BeeBehaviour BeeBehaviour { get; init; }

    public required SwarmingState SwarmingState { get; init; }

    public bool IsQueenPresent { get; init; }

    public bool AreEggsPresent { get; init; }

    public bool AreQueenCellsPresent { get; init; }

    public bool AreDroneCellsPresent { get; init; }

    public required string Notes { get; init; }

}
