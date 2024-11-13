using ApiaryManagementSystem.Domain.Common;

namespace ApiaryManagementSystem.Domain.Models.Inspections;

public sealed class Inspection(
    DateTime inspectionDate,
    ColonyStrength colonyStrength,
    Frames cappedBrood,
    Frames uncappedBrood,
    Frames withHoney,
    Frames withPollen,
    Frames withFreeSpace,
    BroodPattern broodPattern,
    BeeBehaviour beeBehaviour,
    SwarmingState swarmingState,
    bool isQueenPresent,
    bool areEggsPresent,
    bool areQueenCellsPresent,
    bool areDroneCellPresent,
    string? notes) : BaseAuditableEntity
{
    public DateTime InspectionDate { get; init; } = inspectionDate;

    public required ColonyStrength ColonyStrength { get; init; } = colonyStrength;

    public required Frames CappedBrood { get; init; } = cappedBrood;

    public required Frames UncappedBrood { get; init; } = uncappedBrood;

    public required Frames WithHoney { get; init; } = withHoney;

    public required Frames WithPollen { get; init; } = withPollen;

    public required Frames WithFreeSpace { get; init; } = withFreeSpace;

    public required BroodPattern BroodPattern { get; init; } = broodPattern;

    public required BeeBehaviour BeeBehaviour { get; init; } = beeBehaviour;

    public required SwarmingState SwarmingState { get; init; } = swarmingState;

    public bool IsQueenPresent { get; init; } = isQueenPresent;

    public bool AreEggsPresent { get; init; } = areEggsPresent;

    public bool AreQueenCellsPresent { get; init; } = areQueenCellsPresent;

    public bool AreDroneCellsPresent { get; init; } = areDroneCellPresent;

    public string? Notes { get; init; } = notes;
}
