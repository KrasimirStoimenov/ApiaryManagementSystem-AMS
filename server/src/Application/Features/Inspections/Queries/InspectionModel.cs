namespace ApiaryManagementSystem.Application.Features.Inspections.Queries;

public sealed record InspectionModel(
    Guid Id,
    DateTime InspectionDate,
    string ColonyStrength,
    string FramesWithCappedBrood,
    string FramesWithUncappedBrood,
    string FramesWithHoney,
    string FramesWithPollen,
    string FramesWithFreeSpace,
    string BroodPattern,
    string BeeBehaviour,
    string SwarmingState,
    bool IsQueenPresent,
    bool AreEggsPresent,
    bool AreQueenCellsPresent,
    bool AreDroneCellsPresent,
    string? Notes,
    Guid HiveId);
