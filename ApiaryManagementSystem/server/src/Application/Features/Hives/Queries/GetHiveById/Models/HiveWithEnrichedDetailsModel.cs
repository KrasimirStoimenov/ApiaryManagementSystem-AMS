namespace ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById.Models;

public sealed record HiveWithEnrichedDetailsModel(
    Guid Id,
    string Number,
    string Type,
    string Status,
    string? Color,
    DateOnly DateBought,
    string ApiaryName,
    string ApiaryLocation,
    int InspectionsCount,
    int HarvestsCount,
    int DiseasesCount);
