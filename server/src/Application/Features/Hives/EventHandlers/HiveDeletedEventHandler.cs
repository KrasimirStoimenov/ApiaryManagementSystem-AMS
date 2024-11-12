namespace ApiaryManagementSystem.Application.Features.Hives.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Hives;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class HiveDeletedEventHandler(ILogger<HiveDeletedEventHandler> logger) : INotificationHandler<HiveDeletedEvent>
{
    public Task Handle(HiveDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
