namespace ApiaryManagementSystem.Application.UnitTests.Common.Mappings;

using System.Reflection;
using ApiaryManagementSystem.Application.Common.Interfaces;
using AutoMapper;
using Xunit;

public class MappingTests
{
    private readonly IConfigurationProvider configuration;
    private readonly IMapper mapper;

    public MappingTests()
    {
        this.configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        this.mapper = this.configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        this.configuration.AssertConfigurationIsValid();
    }
}
