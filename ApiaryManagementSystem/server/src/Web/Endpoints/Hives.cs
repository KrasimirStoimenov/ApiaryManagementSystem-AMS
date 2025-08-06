namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Hives.Commands.CreateHive;
using ApiaryManagementSystem.Application.Features.Hives.Commands.DeleteHive;
using ApiaryManagementSystem.Application.Features.Hives.Commands.UpdateHive;
using ApiaryManagementSystem.Application.Features.Hives.Queries;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById.Models;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHives;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Hives : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(this.GetHives)
            .MapGet(this.GetHiveById, "{id}")
            .MapPost(this.CreateHive)
            .MapPut(this.UpdateHive, "{id}")
            .MapDelete(this.DeleteHive, "{id}");
    }

    public async Task<PaginatedList<HiveModel>> GetHives(ISender sender, string? searchTerm, int page = 1, int pageSize = 10)
        => await sender.Send(new GetHivesQuery
        {
            SearchTerm = searchTerm,
            Page = page,
            PageSize = pageSize
        });

    public async Task<HiveWithEnrichedDetailsModel> GetHiveById(ISender sender, Guid id)
        => await sender.Send(new GetHiveByIdQuery() { HiveId = id });

    public async Task<IResult> CreateHive(ISender sender, CreateHiveCommand command)
    {
        var hiveId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetHiveById), new { id = hiveId }, hiveId);
    }

    public async Task<IResult> UpdateHive(ISender sender, Guid id, UpdateHiveCommand command)
    {
        if (id != command.Id)
        {
            return Results.Problem(type: "Bad request",
                title: "Not matched ids",
                detail: "Ids for url and command not matched.",
                statusCode: StatusCodes.Status400BadRequest);
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> DeleteHive(ISender sender, Guid id)
    {
        await sender.Send(new DeleteHiveCommand() { Id = id });

        return Results.NoContent();
    }
}
