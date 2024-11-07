namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events.Apiaries;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using MediatR;

public sealed class CreateApiaryCommand : IRequest<Guid>
{
    public required string Name { get; init; }

    public required string Location { get; init; }

    internal sealed class CreateApiaryCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateApiaryCommand, Guid>
    {
        public async Task<Guid> Handle(CreateApiaryCommand request, CancellationToken cancellationToken)
        {
            var apiary = new Apiary(request.Name, request.Location);

            dbContext.Apiaries.Add(apiary);

            apiary.AddDomainEvent(new ApiaryCreatedEvent());

            await dbContext.SaveChangesAsync(cancellationToken);

            return apiary.Id;
        }
    }
}
