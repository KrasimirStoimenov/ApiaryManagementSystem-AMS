namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Harvests.Commands.CreateHarvest;
using ApiaryManagementSystem.Application.Features.Harvests.Commands.DeleteHarvest;
using ApiaryManagementSystem.Application.Features.Harvests.Commands.UpdateHarvest;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class Harvests : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateHarvest)
            .MapPut(UpdateHarvest, "{id}")
            .MapDelete(DeleteHarvest, "{id}");
    }

    public async Task<IResult> CreateHarvest(ISender sender, CreateHarvestCommand command)
    {
        var harvestId = await sender.Send(command);

        return Results.Ok(harvestId);
        //return Results.CreatedAtRoute("TBC", new { id = harvestId }, harvestId);
    }

    public async Task<IResult> UpdateHarvest(ISender sender, Guid id, UpdateHarvestCommand command)
    {
        if (id != command.Id)
        {
            return Results.Problem(
                type: "Bad request",
                title: "Not matched ids",
                detail: "Ids for url and command not matched.",
                statusCode: StatusCodes.Status400BadRequest);
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> DeleteHarvest(ISender sender, Guid id)
    {
        await sender.Send(new DeleteHarvestCommand() { HarvestId = id });

        return Results.NoContent();
    }
}
