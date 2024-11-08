namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.DeleteApiary;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Apiaries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed class DeleteApiaryCommand() : IRequest
{
    public Guid Id { get; init; }

    internal sealed class DeleteApiaryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteApiaryCommand>
    {
        public async Task Handle(DeleteApiaryCommand request, CancellationToken cancellationToken)
        {
            var apiary = await dbContext.Apiaries
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            Guard.Against.NotFound(request.Id, apiary);

            dbContext.Apiaries.Remove(apiary);

            apiary.AddDomainEvent(new ApiaryDeletedEvent());

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
