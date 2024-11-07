using ApiaryManagementSystem.Application.Common.Interfaces;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
namespace TestProject.Application.UnitTests.Common.Behaviours;

using ApiaryManagementSystem.Application.Common.Behaviours;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateApiaryCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;
    private LoggingBehaviour<CreateApiaryCommand> _requestLogger;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateApiaryCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
        _requestLogger = new LoggingBehaviour<CreateApiaryCommand>(_logger.Object, _user.Object, _identityService.Object);
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        await this._requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        await this._requestLogger.Process(new CreateApiaryCommand { Name = "TestName", Location = "TestLocation" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
