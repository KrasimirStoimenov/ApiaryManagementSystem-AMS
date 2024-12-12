namespace ApiaryManagementSystem.Application.UnitTests.Features.Apiaries;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

public abstract class ApiaryDbContextMock
{
    protected ApiaryDbContextMock()
    {
        this.DbContextMock = Substitute.For<IApplicationDbContext>();
        this.ApiariesDbSetMock = Substitute.For<DbSet<Apiary>>();
    }

    internal IApplicationDbContext DbContextMock { get; init; }

    internal DbSet<Apiary> ApiariesDbSetMock { get; init; }
}
