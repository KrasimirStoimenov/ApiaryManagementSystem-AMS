namespace ApiaryManagementSystem.Application.Features.Inspections.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Inspections;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class InspectionDeletedEventHandler(ILogger<InspectionDeletedEventHandler> logger) : INotificationHandler<InspectionDeletedEvent>
{
    public Task Handle(InspectionDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
