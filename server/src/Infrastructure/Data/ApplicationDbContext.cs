﻿namespace ApiaryManagementSystem.Infrastructure.Data;

using System.Reflection;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using ApiaryManagementSystem.Domain.Models.Hives;
using ApiaryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<Apiary> Apiaries => Set<Apiary>();

    public DbSet<Hive> Hives => Set<Hive>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
