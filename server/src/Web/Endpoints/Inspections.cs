namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.DeleteInspection;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.UpdateInspection;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Inspections : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateInspection)
            .MapPut(UpdateInspection, "{id}")
            .MapDelete(DeleteInspection, "{id}");
    }

    public async Task<IResult> CreateInspection(ISender sender, CreateInspectionCommand command)
    {
        var inspectionId = await sender.Send(command);

        //return Results.CreatedAtRoute(nameof(GetHiveById), new { id = hiveId }, hiveId);

        return Results.Ok(inspectionId);
    }

    public async Task<IResult> UpdateInspection(ISender sender, Guid id, UpdateInspectionCommand command)
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

    public async Task<IResult> DeleteInspection(ISender sender, Guid id)
    {
        await sender.Send(new DeleteInspectionCommand() { Id = id });

        return Results.Ok();
    }
}
