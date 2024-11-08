using ApiaryManagementSystem.Application.Common.Interfaces;
namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.UpdateApiary;

using ApiaryManagementSystem.Domain.Events.Apiaries;
using Ardalis.GuardClauses;
using MediatR;

public sealed class UpdateApiaryCommand : IRequest
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required string Location { get; init; }

}

internal sealed class UpdateApiaryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<UpdateApiaryCommand>
{
    public async Task Handle(UpdateApiaryCommand request, CancellationToken cancellationToken)
    {
        var apiary = await dbContext.Apiaries
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, apiary);

        apiary
            .UpdateName(request.Name)
            .UpdateLocation(request.Location);

        apiary.AddDomainEvent(new ApiaryUpdatedEvent());

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

