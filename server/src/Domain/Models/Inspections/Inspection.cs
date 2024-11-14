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

    public ColonyStrength ColonyStrength { get; init; } = colonyStrength;

    public Frames FramesWithCappedBrood { get; init; } = framesWithCappedBrood;

    public Frames FramesWithUncappedBrood { get; init; } = framesWithUncappedBrood;

    public Frames FramesWithHoney { get; init; } = framesWithHoney;

    public Frames FramesWithPollen { get; init; } = framesWithPollen;

    public Frames FramesWithFreeSpace { get; init; } = framesWithFreeSpace;

    public BroodPattern BroodPattern { get; init; } = broodPattern;

    public BeeBehaviour BeeBehaviour { get; init; } = beeBehaviour;

    public SwarmingState SwarmingState { get; init; } = swarmingState;

    public bool IsQueenPresent { get; init; } = isQueenPresent;

    public bool AreEggsPresent { get; init; } = areEggsPresent;

    public bool AreQueenCellsPresent { get; init; } = areQueenCellsPresent;

    public bool AreDroneCellsPresent { get; init; } = areDroneCellsPresent;

    public string? Notes { get; init; } = notes;

    public Guid HiveId { get; init; } = hiveId;

    public Hive Hive { get; init; } = null!;    // Required reference navigation to principal
}
