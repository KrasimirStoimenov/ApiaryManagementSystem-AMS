namespace ApiaryManagementSystem.Domain.Models.Apiaries;

using ApiaryManagementSystem.Domain.Common;

public sealed class Apiary : BaseAuditableEntity<Guid>
{
    public required string Name { get; init; }

    public required string Location { get; init; }
}
