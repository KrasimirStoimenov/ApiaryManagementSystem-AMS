namespace ApiaryManagementSystem.Application.UnitTests.Features.Apiaries.Commands.CreateApiary;

using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using FluentValidation.TestHelper;
using Xunit;

public class CreateApiaryCommandValidatorTests
{
    private readonly CreateApiaryCommandValidator validator;

    public CreateApiaryCommandValidatorTests()
    {
        this.validator = new CreateApiaryCommandValidator();
    }

    [Fact]
    public async Task Validate_ShouldPass_WhenAllPropertiesAreValid()
    {
        // Arrange
        var command = new CreateApiaryCommand
        {
            Name = "Valid Name",
            Location = "Valid Location"
        };

        // Act
        var result = await this.validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("Test name with maximum length (50 characters or more)")]
    public async Task Should_HaveValidationError_WhenNameIsNotValid(string? name)
    {
        //Arrange
        var command = new CreateApiaryCommand()
        {
            Name = name!,
            Location = "Valid Location",
        };

        //Act
        var result = await this.validator.TestValidateAsync(command);

        //Assert
        result.ShouldHaveValidationErrorFor(c => c.Name).Only();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("Test location with maximum length (50 characters or more)")]
    public async Task Should_HaveValidationError_WhenLocationIsNotValid(string? location)
    {
        //Arrange
        var command = new CreateApiaryCommand()
        {
            Name = "Valid Name",
            Location = location!,
        };

        //Act
        var result = await this.validator.TestValidateAsync(command);

        //Assert
        result.ShouldHaveValidationErrorFor(c => c.Location).Only();
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("Test name with maximum length (50 characters or more)",
        "Test location with maximum length (50 characters or more)")]
    public async Task Should_HaveValidationError_WhenNameAndLocationAreNotValid(string? name, string? location)
    {
        //Arrange
        var command = new CreateApiaryCommand()
        {
            Name = name!,
            Location = location!,
        };

        //Act
        var result = await this.validator.TestValidateAsync(command);

        //Assert
        result.ShouldHaveValidationErrorFor(c => c.Name);
        result.ShouldHaveValidationErrorFor(c => c.Location);
    }
}
