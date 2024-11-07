namespace ApiaryManagementSystem.Domain.Events;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public class ApiaryCreatedEvent(Apiary apiary) : BaseEvent
{
    public Apiary Apiary { get; } = apiary;
}
