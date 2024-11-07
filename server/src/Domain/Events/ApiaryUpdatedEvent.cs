namespace ApiaryManagementSystem.Domain.Events;

using ApiaryManagementSystem.Domain.Common;

public sealed class ApiaryUpdatedEvent(Guid apiaryId) : BaseEvent
{
    public Guid ApiaryId { get; } = apiaryId;
}
