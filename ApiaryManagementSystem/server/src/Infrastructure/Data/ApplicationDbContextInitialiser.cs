namespace ApiaryManagementSystem.Infrastructure.Data;

using ApiaryManagementSystem.Domain.Constants;
using ApiaryManagementSystem.Infrastructure.Identity;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
{
    public async Task InitialiseAsync()
    {
        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        try
        {
            await TrySeedAdminAsync(configuration);
            await TrySeedDataAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAdminAsync(IConfiguration configuration)
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var email = configuration["Administrator:Email"];
        var username = configuration["Administrator:Username"];
        var password = configuration["Administrator:Password"];

        Guard.Against.NullOrEmpty(email, message: "Administrator 'Email' not found.");
        Guard.Against.NullOrEmpty(username, message: "Administrator 'Username' not found.");
        Guard.Against.NullOrEmpty(password, message: "Administrator 'Password' not found.");


        var administrator = new ApplicationUser
        {
            UserName = username,
            Email = email
        };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, password!);

            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await userManager.AddToRolesAsync(administrator, [administratorRole.Name]);
            }
        }
    }

    private static async Task TrySeedDataAsync()
    {
        // Default data
        // Seed, if necessary
        await Task.CompletedTask;
    }
}
