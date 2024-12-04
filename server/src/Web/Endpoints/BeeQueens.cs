namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.CreateBeeQueen;
using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.DeleteBeeQueen;
using ApiaryManagementSystem.Application.Features.BeeQueens.Queries;
using ApiaryManagementSystem.Application.Features.BeeQueens.Queries.GetBeeQueenById;
using ApiaryManagementSystem.Application.Features.BeeQueens.Queries.GetBeeQueens;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public class BeeQueens : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetBeeQueens)
            .MapGet(GetBeeQueenById, "{id}")
            .MapPost(CreateBeeQueen)
            .MapDelete(DeleteBeeQueen, "{id}");
    }

    public async Task<PaginatedList<BeeQueenModel>> GetBeeQueens(ISender sender, [AsParameters] GetBeeQueensQuery query)
        => await sender.Send(query);

    public async Task<BeeQueenModel> GetBeeQueenById(ISender sender, Guid id)
        => await sender.Send(new GetBeeQueenByIdQuery() { BeeQueenId = id });

    public async Task<IResult> CreateBeeQueen(ISender sender, CreateBeeQueenCommand command)
    {
        var beeQueenId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetBeeQueenById), new { id = beeQueenId }, beeQueenId);
    }

    public async Task<IResult> DeleteBeeQueen(ISender sender, Guid id)
    {
        await sender.Send(new DeleteBeeQueenCommand() { BeeQueenId = id });

        return Results.NoContent();
    }
}
