namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.CreateBeeQueen;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class BeeQueens : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateBeeQueen);
    }

    public async Task<IResult> CreateBeeQueen(ISender sender, CreateBeeQueenCommand command)
    {
        var beeQueenId = await sender.Send(command);

        return Results.CreatedAtRoute("TBC", new { x = beeQueenId }, beeQueenId);
    }
}
