using ApiaryManagementSystem.Domain.Models.Apiaries;

namespace ApiaryManagementSystem.Domain.Events;

public class ApiaryCreatedEvent : BaseEvent
{
    public ApiaryCreatedEvent(Apiary apiary)
        => Apiary = apiary;

    public Apiary Apiary { get; }
}
