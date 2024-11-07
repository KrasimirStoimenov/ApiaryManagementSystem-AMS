namespace ApiaryManagementSystem.Application.Common.Interfaces;

using ApiaryManagementSystem.Domain.Models.Apiaries;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Apiary> Apiaries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
