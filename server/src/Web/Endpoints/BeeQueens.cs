namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.CreateBeeQueen;
using ApiaryManagementSystem.Application.Features.BeeQueens.Queries;
using ApiaryManagementSystem.Application.Features.BeeQueens.Queries.GetBeeQueenById;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class BeeQueens : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBeeQueenById, "{id}")
            .MapPost(CreateBeeQueen);
    }

    public async Task<BeeQueenModel> GetBeeQueenById(ISender sender, Guid id)
        => await sender.Send(new GetBeeQueenByIdCommand() { BeeQueenId = id });

    public async Task<IResult> CreateBeeQueen(ISender sender, CreateBeeQueenCommand command)
    {
        var beeQueenId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetBeeQueenById), new { id = beeQueenId }, beeQueenId);
    }
}
