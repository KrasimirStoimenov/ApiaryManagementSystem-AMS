namespace ApiaryManagementSystem.Application.Features.Harvests.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Harvests;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class HarvestUpdatedEventHandler(ILogger<HarvestUpdatedEventHandler> logger) : INotificationHandler<HarvestsUpdatedEvent>
{
    public Task Handle(HarvestsUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
