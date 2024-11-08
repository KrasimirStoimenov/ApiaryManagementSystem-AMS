namespace ApiaryManagementSystem.Domain.Models.Hives;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public sealed class Hive(
    string number,
    string type,
    string status,
    string? color,
    DateOnly dateBought,
    Guid apiaryId) : BaseAuditableEntity
{
    public string Number { get; init; } = number;

    public string Type { get; init; } = type;

    public string Status { get; init; } = status;

    public string? Color { get; init; } = color;

    public DateOnly DateBought { get; init; } = dateBought;

    public Guid ApiaryId { get; init; } = apiaryId;

    public Apiary Apiary { get; init; } = null!;    // Required reference navigation to principal
}
