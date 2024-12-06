namespace ApiaryManagementSystem.Domain.Models.Harvests;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Hives;

public sealed class Harvest(
    DateTime date,
    decimal amount,
    string product,
    Guid hiveId) : BaseAuditableEntity
{
    public DateTime Date { get; private set; } = date;

    public decimal Amount { get; private set; } = amount;

    public string Product { get; private set; } = product; //(e.g., Honey, Beeswax, Pollen, Propolis)

    public Guid HiveId { get; private set; } = hiveId;

    public Hive Hive { get; init; } = null!;    // Required reference navigation to principal

    public void UpdateHarvest(
    DateTime date,
    decimal amount,
    string product,
    Guid hiveId)
    {
        this.Date = date;
        this.Amount = amount;
        this.Product = product;
        this.HiveId = hiveId;
    }
}
