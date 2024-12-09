namespace ApiaryManagementSystem.Application.Features.Diseases.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Diseases;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class DiseaseDeletedEventHandler(ILogger<DiseaseDeletedEventHandler> logger) : INotificationHandler<DiseaseDeletedEvent>
{
    public Task Handle(DiseaseDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
