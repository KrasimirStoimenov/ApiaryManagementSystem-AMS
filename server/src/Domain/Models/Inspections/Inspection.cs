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
    public DateTime InspectionDate { get; private set; } = inspectionDate;

    public ColonyStrength ColonyStrength { get; private set; } = colonyStrength;

    public Frames FramesWithCappedBrood { get; private set; } = framesWithCappedBrood;

    public Frames FramesWithUncappedBrood { get; private set; } = framesWithUncappedBrood;

    public Frames FramesWithHoney { get; private set; } = framesWithHoney;

    public Frames FramesWithPollen { get; private set; } = framesWithPollen;

    public Frames FramesWithFreeSpace { get; private set; } = framesWithFreeSpace;

    public BroodPattern BroodPattern { get; private set; } = broodPattern;

    public BeeBehaviour BeeBehaviour { get; private set; } = beeBehaviour;

    public SwarmingState SwarmingState { get; private set; } = swarmingState;

    public bool IsQueenPresent { get; private set; } = isQueenPresent;

    public bool AreEggsPresent { get; private set; } = areEggsPresent;

    public bool AreQueenCellsPresent { get; private set; } = areQueenCellsPresent;

    public bool AreDroneCellsPresent { get; private set; } = areDroneCellsPresent;

    public string? Notes { get; private set; } = notes;

    public Guid HiveId { get; private set; } = hiveId;

    public Hive Hive { get; init; } = null!;    // Required reference navigation to principal

    public void UpdateInspection(
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
        Guid hiveId)
    {
        this.InspectionDate = inspectionDate;
        this.ColonyStrength = colonyStrength;
        this.FramesWithCappedBrood = framesWithCappedBrood;
        this.FramesWithUncappedBrood = framesWithUncappedBrood;
        this.FramesWithHoney = framesWithHoney;
        this.FramesWithPollen = framesWithPollen;
        this.FramesWithFreeSpace = framesWithFreeSpace;
        this.BroodPattern = broodPattern;
        this.BeeBehaviour = beeBehaviour;
        this.SwarmingState = swarmingState;
        this.IsQueenPresent = isQueenPresent;
        this.AreEggsPresent = areEggsPresent;
        this.AreQueenCellsPresent = areQueenCellsPresent;
        this.AreDroneCellsPresent = areDroneCellsPresent;
        this.Notes = notes;
        this.HiveId = hiveId;

    }
}
