namespace ApiaryManagementSystem.Domain.Models.BeeQueens;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Hives;

public sealed class BeeQueen(
    int year,
    string? colorMark,
    bool isAlive,
    Guid hiveId) : BaseAuditableEntity
{
    public int Year { get; private set; } = year;

    public string? ColorMark { get; private set; } = colorMark;

    public bool IsAlive { get; private set; } = isAlive;

    public Guid HiveId { get; private set; } = hiveId;

    public Hive Hive { get; init; } = null!;    // Required reference navigation to principal

    public void UpdateBeeQueen(
        int year,
        string? colorMark,
        bool isAlive,
        Guid hiveId)
    {
        this.Year = year;
        this.ColorMark = colorMark;
        this.IsAlive = isAlive;
        this.HiveId = hiveId;
    }
}
