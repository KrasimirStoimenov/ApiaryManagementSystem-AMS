namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Hives;
using ApiaryManagementSystem.Application.Features.Hives.Commands.CreateHive;
using ApiaryManagementSystem.Application.Features.Hives.Commands.DeleteHive;
using ApiaryManagementSystem.Application.Features.Hives.Commands.UpdateHive;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHiveById;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Hives : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetHiveById, "{id}")
            .MapPost(CreateHive)
            .MapPut(UpdateHive, "{id}")
            .MapDelete(DeleteHive, "{id}");
    }

    public async Task<HiveModel> GetHiveById(ISender sender, Guid id)
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
            //TODO: Refactor to returns more specific error
            return Results.BadRequest("Ids for url and command not matched.");
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> DeleteHive(ISender sender, Guid id)
    {
        await sender.Send(new DeleteHiveCommand() { Id = id });

        return Results.Ok();
    }
}
