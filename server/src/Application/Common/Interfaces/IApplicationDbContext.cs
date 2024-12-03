namespace ApiaryManagementSystem.Application.Common.Interfaces;

using ApiaryManagementSystem.Domain.Models.Apiaries;
using ApiaryManagementSystem.Domain.Models.BeeQueens;
using ApiaryManagementSystem.Domain.Models.Hives;
using ApiaryManagementSystem.Domain.Models.Inspections;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Apiary> Apiaries { get; }

    DbSet<Hive> Hives { get; }

    DbSet<BeeQueen> BeeQueens { get; }

    DbSet<Inspection> Inspections { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
