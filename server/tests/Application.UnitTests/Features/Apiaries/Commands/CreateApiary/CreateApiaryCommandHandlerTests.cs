namespace ApiaryManagementSystem.Application.UnitTests.Features.Apiaries.Commands.CreateApiary;

using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using ApiaryManagementSystem.Domain.Events.Apiaries;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using NSubstitute;
using Xunit;

public class CreateApiaryCommandHandlerTests : ApiaryDbContextMock
{
    private readonly CreateApiaryCommandHandler sut;
    private readonly CreateApiaryCommand command;

    public CreateApiaryCommandHandlerTests()
    {
        this.sut = new CreateApiaryCommandHandler(this.DbContextMock);

        this.command = new CreateApiaryCommand
        {
            Name = "Test Apiary",
            Location = "Test Location"
        };
    }

    [Fact]
    public async Task Handle_ShouldCreateApiary()
    {
        // Arrange
        this.DbContextMock.Apiaries
            .Returns(this.ApiariesDbSetMock);

        // Act
        var apiaryId = await this.sut.Handle(this.command, CancellationToken.None);

        // Assert
        this.ApiariesDbSetMock.Received(1).Add(Arg.Is<Apiary>(a =>
            a.Name == this.command.Name &&
            a.Location == this.command.Location));

        await this.DbContextMock.Received(1).SaveChangesAsync(CancellationToken.None);
    }

    [Fact]
    public async Task Handle_ShouldAddDomainEvent()
    {
        // Arrange
        this.DbContextMock.Apiaries
            .Returns(this.ApiariesDbSetMock);

        // Act
        var result = await this.sut.Handle(this.command, CancellationToken.None);

        // Assert
        this.ApiariesDbSetMock.Received(1).Add(Arg.Is<Apiary>(a =>
            a.DomainEvents.Any(e => e is ApiaryCreatedEvent)));

        await this.DbContextMock.Received(1).SaveChangesAsync(CancellationToken.None);
    }
}
