namespace ApiaryManagementSystem.Domain.Common;

public abstract class BaseAuditableEntity<TId> : BaseEntity<TId>
    where TId : struct
{
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
