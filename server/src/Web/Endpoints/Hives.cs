namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Hives.Commands.CreateHive;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Hives : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateHive);
    }

    public async Task<IResult> CreateHive(ISender sender, CreateHiveCommand command)
    {
        var hiveId = await sender.Send(command);

        return Results.CreatedAtRoute("GetHiveById", new { id = hiveId }, hiveId);
    }
}
