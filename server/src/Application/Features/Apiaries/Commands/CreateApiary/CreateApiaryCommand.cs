namespace ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;

using System.Threading;
using System.Threading.Tasks;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Events;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public sealed class CreateApiaryCommand : IRequest<Guid>
{
    public required string Name { get; init; }

    public required string Location { get; init; }

    internal sealed class CreateApiaryCommandHandler(
        IApplicationDbContext applicationDbContext) : IRequestHandler<CreateApiaryCommand, Guid>
    {
        public async Task<Guid> Handle(CreateApiaryCommand request, CancellationToken cancellationToken)
        {
            var apiary = new Apiary
            {
                Name = request.Name,
                Location = request.Location,
            };

            apiary.AddDomainEvent(new ApiaryCreatedEvent(apiary));

            applicationDbContext.Apiaries.Add(apiary);

            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return apiary.Id;
        }
    }
}
