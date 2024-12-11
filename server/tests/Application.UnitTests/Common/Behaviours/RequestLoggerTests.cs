namespace ApiaryManagementSystem.Application.UnitTests.Common.Behaviours;

using ApiaryManagementSystem.Application.Common.Behaviours;
using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public class RequestLoggerTests
{
    private readonly ILogger<CreateApiaryCommand> _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;
    private readonly LoggingBehaviour<CreateApiaryCommand> _requestLogger;

    public RequestLoggerTests()
    {
        _logger = Substitute.For<ILogger<CreateApiaryCommand>>();
        _user = Substitute.For<IUser>();
        _identityService = Substitute.For<IIdentityService>();
        _requestLogger = new LoggingBehaviour<CreateApiaryCommand>(_logger, _user, _identityService);
    }

    [Fact]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Id.Returns(Guid.NewGuid().ToString());

        await _requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        await _identityService.Received().GetUserNameAsync(Arg.Any<string>());
    }

    [Fact]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        await _requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        await _identityService.DidNotReceive().GetUserNameAsync(Arg.Any<string>());
    }
}
