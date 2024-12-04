namespace ApiaryManagementSystem.Application.Features.BeeQueens.Queries;

public sealed record BeeQueenModel(
    Guid Id,
    int Year,
    string? ColorMark,
    bool IsAlive,
    Guid HiveId);
