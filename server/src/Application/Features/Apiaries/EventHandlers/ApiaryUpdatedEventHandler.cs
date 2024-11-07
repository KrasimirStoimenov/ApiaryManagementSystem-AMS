namespace ApiaryManagementSystem.Application.Features.Apiaries.EventHandlers;

using ApiaryManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class ApiaryUpdatedEventHandler(ILogger<ApiaryUpdatedEventHandler> logger) : INotificationHandler<ApiaryUpdatedEvent>
{
    public Task Handle(ApiaryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
