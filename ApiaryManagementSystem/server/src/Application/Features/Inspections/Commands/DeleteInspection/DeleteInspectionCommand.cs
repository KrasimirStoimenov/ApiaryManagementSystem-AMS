namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.DeleteInspection;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Inspections;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class DeleteInspectionCommand : IRequest
{
    public required Guid Id { get; init; }
}

internal sealed class DeleteInspectionCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteInspectionCommand>
{
    public async Task Handle(DeleteInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = await dbContext.Inspections
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, inspection);

        dbContext.Inspections.Remove(inspection);

        inspection.AddDomainEvent(new InspectionDeletedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
