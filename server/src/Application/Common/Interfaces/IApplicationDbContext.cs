namespace ApiaryManagementSystem.Application.Common.Interfaces;

using ApiaryManagementSystem.Domain.Models.Apiaries;

public interface IApplicationDbContext
{
    DbSet<Apiary> Apiaries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
