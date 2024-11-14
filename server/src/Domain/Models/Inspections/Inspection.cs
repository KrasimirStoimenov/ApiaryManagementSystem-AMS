using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Hives;

namespace ApiaryManagementSystem.Domain.Models.Inspections;

public sealed class Inspection(
    DateTime inspectionDate,
    ColonyStrength colonyStrength,
    Frames framesWithCappedBrood,
    Frames framesWithUncappedBrood,
    Frames framesWithHoney,
    Frames framesWithPollen,
    Frames framesWithFreeSpace,
    BroodPattern broodPattern,
    BeeBehaviour beeBehaviour,
    SwarmingState swarmingState,
    bool isQueenPresent,
    bool areEggsPresent,
    bool areQueenCellsPresent,
    bool areDroneCellsPresent,
    string? notes,
    Guid hiveId) : BaseAuditableEntity
{
    public DateTime InspectionDate { get; init; } = inspectionDate;

    public required ColonyStrength ColonyStrength { get; init; } = colonyStrength;

    public required Frames FramesWithCappedBrood { get; init; } = framesWithCappedBrood;

    public required Frames FramesWithUncappedBrood { get; init; } = framesWithUncappedBrood;

    public required Frames FramesWithHoney { get; init; } = framesWithHoney;

    public required Frames FramesWithPollen { get; init; } = framesWithPollen;

    public required Frames FramesWithFreeSpace { get; init; } = framesWithFreeSpace;

    public required BroodPattern BroodPattern { get; init; } = broodPattern;

    public required BeeBehaviour BeeBehaviour { get; init; } = beeBehaviour;

    public required SwarmingState SwarmingState { get; init; } = swarmingState;

    public bool IsQueenPresent { get; init; } = isQueenPresent;

    public bool AreEggsPresent { get; init; } = areEggsPresent;

    public bool AreQueenCellsPresent { get; init; } = areQueenCellsPresent;

    public bool AreDroneCellsPresent { get; init; } = areDroneCellsPresent;

    public string? Notes { get; init; } = notes;

    public Guid HiveId { get; init; } = hiveId;

    public Hive Hive { get; init; } = null!;    // Required reference navigation to principal
}
