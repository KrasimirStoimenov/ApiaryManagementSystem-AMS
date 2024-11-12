namespace ApiaryManagementSystem.Application.Features.Hives.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Hives;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class HiveUpdatedEventHandler(ILogger<HiveUpdatedEventHandler> logger) : INotificationHandler<HiveUpdatedEvent>
{
    public Task Handle(HiveUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
