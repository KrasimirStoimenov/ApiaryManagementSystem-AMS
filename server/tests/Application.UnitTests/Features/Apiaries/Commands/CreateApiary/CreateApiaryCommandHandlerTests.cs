namespace ApiaryManagementSystem.Application.UnitTests.Features.Apiaries.Commands.CreateApiary;

using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using ApiaryManagementSystem.Domain.Events.Apiaries;
using ApiaryManagementSystem.Domain.Models.Apiaries;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

public class CreateApiaryCommandHandlerTests
{
    private readonly IApplicationDbContext dbContext;
    private readonly DbSet<Apiary> apiariesDbSet;
    private readonly CreateApiaryCommandHandler sut;
    private readonly CreateApiaryCommand command;

    public CreateApiaryCommandHandlerTests()
    {
        this.dbContext = Substitute.For<IApplicationDbContext>();
        this.apiariesDbSet = Substitute.For<DbSet<Apiary>>();

        this.sut = new CreateApiaryCommandHandler(this.dbContext);

        this.command = new CreateApiaryCommand
        {
            Name = "Test Apiary",
            Location = "Test Location"
        };
    }

    [Fact]
    public async Task Handle_ShouldExecuteSaveChangesAndCreateApiary()
    {
        // Arrange
        this.dbContext.Apiaries
            .Returns(this.apiariesDbSet);

        // Act
        var apiaryId = await this.sut.Handle(this.command, CancellationToken.None);

        // Assert
        this.apiariesDbSet.Received(1).Add(Arg.Is<Apiary>(a =>
            a.Name == this.command.Name &&
            a.Location == this.command.Location));

        await this.dbContext.Received(1).SaveChangesAsync(CancellationToken.None);
    }

    [Fact]
    public async Task Handle_ShouldAddDomainEvent()
    {
        // Arrange
        this.dbContext.Apiaries
            .Returns(this.apiariesDbSet);

        var handler = new CreateApiaryCommandHandler(this.dbContext);

        // Act
        var result = await handler.Handle(this.command, CancellationToken.None);

        // Assert
        this.apiariesDbSet.Received(1).Add(Arg.Is<Apiary>(a =>
            a.DomainEvents.Any(e => e is ApiaryCreatedEvent)));

        await this.dbContext.Received(1).SaveChangesAsync(CancellationToken.None);
    }
}
