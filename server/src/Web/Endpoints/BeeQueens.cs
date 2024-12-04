namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.CreateBeeQueen;
using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.DeleteBeeQueen;
using ApiaryManagementSystem.Application.Features.BeeQueens.Commands.UpdateBeeQueen;
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
            .MapPut(UpdateBeeQueen, "{id}")
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

    public async Task<IResult> UpdateBeeQueen(ISender sender, Guid id, UpdateBeeQueenCommand command)
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

    public async Task<IResult> DeleteBeeQueen(ISender sender, Guid id)
    {
        await sender.Send(new DeleteBeeQueenCommand() { BeeQueenId = id });

        return Results.NoContent();
    }
}
