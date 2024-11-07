namespace ApiaryManagementSystem.Application.Features.Apiaries.EventHandlers;

using ApiaryManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class ApiaryUpdatedEventHandler(ILogger<ApiaryUpdatedEventHandler> logger) : INotificationHandler<ApiaryUpdatedEvent>
{
    public Task Handle(ApiaryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("AMS Domain Event: {DomainEvent}. Updated entity id: {DomainEntityId}", notification.GetType().Name, notification.ApiaryId);

        return Task.CompletedTask;
    }
}
