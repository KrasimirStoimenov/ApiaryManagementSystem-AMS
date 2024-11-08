namespace ApiaryManagementSystem.Domain.Models.Hives;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public sealed class Hive : BaseAuditableEntity
{
    public required string Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    public Guid ApiaryId { get; init; }

    public required Apiary Apiary { get; init; }
}
