namespace ApiaryManagementSystem.Application.Features.Hives.Commands.DeleteHive;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Apiaries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class DeleteHiveCommand : IRequest
{
    public required Guid Id { get; init; }
}

internal sealed class DeleteHiveCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteHiveCommand>
{
    public async Task Handle(DeleteHiveCommand request, CancellationToken cancellationToken)
    {
        var hive = await dbContext.Hives
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, hive);

        dbContext.Hives.Remove(hive);

        hive.AddDomainEvent(new ApiaryDeletedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
