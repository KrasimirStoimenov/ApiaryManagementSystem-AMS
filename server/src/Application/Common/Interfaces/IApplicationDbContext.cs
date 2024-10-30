namespace ApiaryManagementSystem.Application.Common.Interfaces;

using ApiaryManagementSystem.Domain.Entities;
using ApiaryManagementSystem.Domain.Models.Apiaries;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Apiary> Apiaries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
