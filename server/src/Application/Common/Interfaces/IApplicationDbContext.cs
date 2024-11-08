namespace ApiaryManagementSystem.Application.Common.Interfaces;

using ApiaryManagementSystem.Domain.Models.Apiaries;
using ApiaryManagementSystem.Domain.Models.Hives;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Apiary> Apiaries { get; }

    DbSet<Hive> Hives { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
