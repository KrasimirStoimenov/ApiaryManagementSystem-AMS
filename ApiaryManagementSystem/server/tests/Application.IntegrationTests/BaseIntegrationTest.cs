namespace ApiaryManagementSystem.Application.IntegrationTests;

using ApiaryManagementSystem.Application.Common.Interfaces;
using AutoFixture;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
    private readonly IServiceScope scope;
    protected readonly ISender sender;
    protected readonly IApplicationDbContext dbContext;
    protected readonly IFixture fixture;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        this.scope = factory.Services.CreateScope();

        this.sender = this.scope.ServiceProvider.GetRequiredService<ISender>();
        this.dbContext = this.scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        this.fixture = new Fixture();
    }

    public void Dispose()
    {
        this.scope?.Dispose();

        GC.SuppressFinalize(this);
    }
}
