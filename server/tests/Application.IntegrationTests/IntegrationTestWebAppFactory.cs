namespace ApiaryManagementSystem.Application.IntegrationTests;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("IntegrationTests");

        builder.ConfigureTestServices(services =>
        {
            var descriptorType = typeof(DbContextOptions<ApplicationDbContext>);
            var descriptor = services.SingleOrDefault(s => s.ServiceType == descriptorType);

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<IApplicationDbContext, ApplicationDbContext>((sp, options)
                    => options.UseInMemoryDatabase("TestDb").UseInternalServiceProvider(sp));
        });
    }
}
