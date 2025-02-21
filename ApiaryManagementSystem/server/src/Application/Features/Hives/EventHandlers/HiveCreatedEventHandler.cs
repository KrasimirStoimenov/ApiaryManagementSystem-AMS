namespace ApiaryManagementSystem.Application.Features.Hives.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Hives;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class HiveCreatedEventHandler(ILogger<HiveCreatedEventHandler> logger) : INotificationHandler<HiveCreatedEvent>
{
    public Task Handle(HiveCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
