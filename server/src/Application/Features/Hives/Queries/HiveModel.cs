namespace ApiaryManagementSystem.Application.Features.Hives.Queries;

public sealed record HiveModel(
    Guid Id,
    string Number,
    string Type,
    string Status,
    string? Color,
    DateOnly DateBought,
    Guid ApiaryId);
