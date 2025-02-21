namespace ApiaryManagementSystem.Application.Features.BeeQueens.EventHandlers;

using ApiaryManagementSystem.Domain.Events.BeeQueens;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class BeeQueenUpdatedEventHandler(ILogger<BeeQueenUpdatedEventHandler> logger) : INotificationHandler<BeeQueenUpdatedEvent>
{
    public Task Handle(BeeQueenUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
