namespace ApiaryManagementSystem.Application.IntegrationTests.Features.Apiaries.Commands;

using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class CreateApiaryTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Create_ShouldCreateApiary()
    {
        // Arrange
        var command = new CreateApiaryCommand
        {
            Name = "Valid Name",
            Location = "Valid Location",
        };

        // Act
        var apiaryId = await this.sender.Send(command);

        // Assert
        var apiary = await this.dbContext.Apiaries.FirstOrDefaultAsync(x => x.Id == apiaryId);

        apiary.Should().NotBeNull();
        apiary!.Name.Should().Be(command.Name);
        apiary.Location.Should().Be(command.Location);
    }
}
