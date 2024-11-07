namespace ApiaryManagementSystem.Web.Services;

using System.Security.Claims;

using ApiaryManagementSystem.Application.Common.Interfaces;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
