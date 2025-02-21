namespace ApiaryManagementSystem.Application.Features.Hives.Commands.CreateHive;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Hives;
using ApiaryManagementSystem.Domain.Models.Hives;
using MediatR;

public sealed class CreateHiveCommand : IRequest<Guid>
{
    public required string Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public required DateOnly DateBought { get; init; }

    public required Guid ApiaryId { get; init; }
}

internal sealed class CreateHiveCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateHiveCommand, Guid>
{
    public async Task<Guid> Handle(CreateHiveCommand request, CancellationToken cancellationToken)
    {
        var hive = new Hive(
            request.Number,
            request.Type,
            request.Status,
            request.Color,
            request.DateBought,
            request.ApiaryId);

        dbContext.Hives.Add(hive);

        hive.AddDomainEvent(new HiveCreatedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);

        return hive.Id;
    }
}
