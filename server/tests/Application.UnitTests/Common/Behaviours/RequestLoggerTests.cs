namespace ApiaryManagementSystem.Application.UnitTests.Common.Behaviours;

using ApiaryManagementSystem.Application.Common.Behaviours;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public class RequestLoggerTests
{
    private readonly ILogger<CreateApiaryCommand> logger;
    private readonly IUser user;
    private readonly IIdentityService identityService;
    private readonly LoggingBehaviour<CreateApiaryCommand> requestLogger;

    public RequestLoggerTests()
    {
        this.logger = Substitute.For<ILogger<CreateApiaryCommand>>();
        this.user = Substitute.For<IUser>();
        this.identityService = Substitute.For<IIdentityService>();
        this.requestLogger = new LoggingBehaviour<CreateApiaryCommand>(this.logger, this.user, this.identityService);
    }

    [Fact]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        this.user.Id.Returns(Guid.NewGuid().ToString());

        await this.requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        await this.identityService.Received().GetUserNameAsync(Arg.Any<string>());
    }

    [Fact]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        await this.requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        await this.identityService.DidNotReceive().GetUserNameAsync(Arg.Any<string>());
    }
}
