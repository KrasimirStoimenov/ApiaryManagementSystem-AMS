namespace ApiaryManagementSystem.Application.UnitTests.Common.Mappings;

using System.Reflection;
using ApiaryManagementSystem.Application.Common.Interfaces;
using AutoMapper;
using Xunit;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }
}
