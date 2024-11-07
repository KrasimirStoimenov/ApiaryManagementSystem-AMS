namespace ApiaryManagementSystem.Application.Features.Apiaries.EventHandlers;

using ApiaryManagementSystem.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class ApiaryCreatedEventHandler(ILogger<ApiaryCreatedEventHandler> logger) : INotificationHandler<ApiaryCreatedEvent>
{
    public Task Handle(ApiaryCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
