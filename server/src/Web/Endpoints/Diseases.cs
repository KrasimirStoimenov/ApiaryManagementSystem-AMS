namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Diseases.Commands.CreateDisease;
using ApiaryManagementSystem.Application.Features.Diseases.Commands.DeleteDisease;
using ApiaryManagementSystem.Application.Features.Diseases.Commands.UpdateDisease;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public sealed class Diseases : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDisease)
            .MapPut(UpdateDisease, "{id}")
            .MapDelete(DeleteDisease, "{id}");
    }

    public async Task<IResult> CreateDisease(ISender sender, CreateDiseaseCommand command)
    {
        var diseaseId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(this.CreateDisease), new { id = diseaseId }, diseaseId);
    }

    public async Task<IResult> UpdateDisease(ISender sender, Guid id, UpdateDiseaseCommand command)
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

    public async Task<IResult> DeleteDisease(ISender sender, Guid id)
    {
        await sender.Send(new DeleteDiseaseCommand() { DiseaseId = id });

        return Results.NoContent();
    }
}
