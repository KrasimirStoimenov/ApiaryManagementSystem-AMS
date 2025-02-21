namespace ApiaryManagementSystem.Application.Features.Harvests.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Harvests;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class HarvestDeletedEventHandler(ILogger<HarvestDeletedEventHandler> logger) : INotificationHandler<HarvestsDeletedEvent>
{
    public Task Handle(HarvestsDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
