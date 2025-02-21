namespace ApiaryManagementSystem.Application.Features.Inspections.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Inspections;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class InspectionUpdatedEventHandler(ILogger<InspectionUpdatedEventHandler> logger) : INotificationHandler<InspectionUpdatedEvent>
{
    public Task Handle(InspectionUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
