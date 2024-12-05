namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Harvests.Commands.CreateHarvest;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class Harvests : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateHarvest);
    }

    public async Task<IResult> CreateHarvest(ISender sender, CreateHarvestCommand command)
    {
        var harvestId = await sender.Send(command);

        return Results.Ok(harvestId);
        //return Results.CreatedAtRoute("TBC", new { id = harvestId }, harvestId);
    }
}
