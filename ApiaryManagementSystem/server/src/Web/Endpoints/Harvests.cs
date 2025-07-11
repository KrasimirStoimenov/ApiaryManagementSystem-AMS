﻿namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Harvests.Commands.CreateHarvest;
using ApiaryManagementSystem.Application.Features.Harvests.Commands.DeleteHarvest;
using ApiaryManagementSystem.Application.Features.Harvests.Commands.UpdateHarvest;
using ApiaryManagementSystem.Application.Features.Harvests.Queries;
using ApiaryManagementSystem.Application.Features.Harvests.Queries.GetHarvestById;
using ApiaryManagementSystem.Application.Features.Harvests.Queries.GetHarvests;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class Harvests : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(this.GetHarvests)
            .MapGet(this.GetHarvestById, "{id}")
            .MapPost(this.CreateHarvest)
            .MapPut(this.UpdateHarvest, "{id}")
            .MapDelete(this.DeleteHarvest, "{id}");
    }

    public async Task<PaginatedList<HarvestModel>> GetHarvests(ISender sender, int page = 1, int pageSize = 10)
        => await sender.Send(new GetHarvestsQuery
        {
            Page = page,
            PageSize = pageSize
        });

    public async Task<HarvestModel> GetHarvestById(ISender sender, Guid id)
        => await sender.Send(new GetHarvestByIdQuery() { HarvestId = id });

    public async Task<IResult> CreateHarvest(ISender sender, CreateHarvestCommand command)
    {
        var harvestId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetHarvestById), new { id = harvestId }, harvestId);
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
