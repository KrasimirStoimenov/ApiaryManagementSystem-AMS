namespace ApiaryManagementSystem.Application.Features.Hives;

public sealed record HiveModel(
    Guid Id,
    string Number,
    string Type,
    string Status,
    string? Color,
    DateOnly DateBought,
    Guid ApiaryId);
