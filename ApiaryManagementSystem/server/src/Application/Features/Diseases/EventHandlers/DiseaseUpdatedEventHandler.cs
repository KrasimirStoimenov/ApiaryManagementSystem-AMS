namespace ApiaryManagementSystem.Application.Features.Diseases.EventHandlers;

using ApiaryManagementSystem.Domain.Events.Diseases;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class DiseaseUpdatedEventHandler(ILogger<DiseaseUpdatedEventHandler> logger) : INotificationHandler<DiseaseUpdatedEvent>
{
    public Task Handle(DiseaseUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event fired: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
