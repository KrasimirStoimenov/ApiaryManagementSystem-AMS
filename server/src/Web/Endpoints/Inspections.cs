namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Inspections : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateInspection);
    }

    public async Task<IResult> CreateInspection(ISender sender, CreateInspectionCommand command)
    {
        var hiveId = await sender.Send(command);

        //return Results.CreatedAtRoute(nameof(GetHiveById), new { id = hiveId }, hiveId);

        return Results.Ok(hiveId);
    }
}
