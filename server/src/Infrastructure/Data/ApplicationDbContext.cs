namespace ApiaryManagementSystem.Infrastructure.Data;

using System.Reflection;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using ApiaryManagementSystem.Domain.Models.BeeQueens;
using ApiaryManagementSystem.Domain.Models.Harvests;
using ApiaryManagementSystem.Domain.Models.Hives;
using ApiaryManagementSystem.Domain.Models.Inspections;
using ApiaryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<Apiary> Apiaries => Set<Apiary>();

    public DbSet<Hive> Hives => Set<Hive>();

    public DbSet<BeeQueen> BeeQueens => Set<BeeQueen>();

    public DbSet<Inspection> Inspections => Set<Inspection>();

    public DbSet<Harvest> Harvests => Set<Harvest>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
