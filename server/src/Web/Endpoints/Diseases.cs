namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Diseases.Commands.CreateDisease;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public sealed class Diseases : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDisease);
    }

    public async Task<IResult> CreateDisease(ISender sender, CreateDiseaseCommand command)
    {
        var diseaseId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(this.CreateDisease), new { id = diseaseId }, diseaseId);
    }
}
