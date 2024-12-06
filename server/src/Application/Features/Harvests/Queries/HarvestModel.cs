namespace ApiaryManagementSystem.Application.Features.Harvests.Queries;

public sealed record HarvestModel(
    Guid Id,
    DateTime Date,
    decimal Amount,
    string Product,
    Guid HiveId);
