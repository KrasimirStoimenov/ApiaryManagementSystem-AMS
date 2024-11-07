namespace ApiaryManagementSystem.Domain.Events;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public class ApiaryCreatedEvent : BaseEvent
{
    public ApiaryCreatedEvent(Apiary apiary)
        => Apiary = apiary;

    public Apiary Apiary { get; }
}
