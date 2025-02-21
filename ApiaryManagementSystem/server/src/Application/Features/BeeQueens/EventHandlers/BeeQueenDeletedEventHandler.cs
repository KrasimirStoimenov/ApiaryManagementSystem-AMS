namespace ApiaryManagementSystem.Application.Features.BeeQueens.EventHandlers;

using ApiaryManagementSystem.Domain.Events.BeeQueens;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class BeeQueenDeletedEventHandler(ILogger<BeeQueenDeletedEventHandler> logger) : INotificationHandler<BeeQueenDeletedEvent>
{
    public Task Handle(BeeQueenDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
