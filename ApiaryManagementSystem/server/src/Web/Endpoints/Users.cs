using ApiaryManagementSystem.Infrastructure.Identity;
namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Web.Infrastructure;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
