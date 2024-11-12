using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Hives;
using Ardalis.GuardClauses;
using MediatR;

namespace ApiaryManagementSystem.Application.Features.Hives.Commands.UpdateHive;

public sealed class UpdateHiveCommand : IRequest
{
    public required Guid Id { get; init; }

    public required string Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public required DateOnly DateBought { get; init; }

    public required Guid ApiaryId { get; init; }
}

internal sealed class UpdateHiveCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateHiveCommand>
{
    public async Task Handle(UpdateHiveCommand request, CancellationToken cancellationToken)
    {
        var hive = await dbContext.Hives
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, hive);

        hive.UpdateHive(
            request.Number,
            request.Type,
            request.Status,
            request.Color,
            request.DateBought,
            request.ApiaryId);

        hive.AddDomainEvent(new HiveUpdatedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
