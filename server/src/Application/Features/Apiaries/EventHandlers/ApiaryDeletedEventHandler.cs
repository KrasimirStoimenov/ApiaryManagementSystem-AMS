namespace ApiaryManagementSystem.Application.Features.Apiaries.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Apiaries;
using MediatR;
using Microsoft.Extensions.Logging;

internal class ApiaryDeletedEventHandler(ILogger<ApiaryCreatedEventHandler> logger) : INotificationHandler<ApiaryDeletedEvent>
{
    public Task Handle(ApiaryDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
