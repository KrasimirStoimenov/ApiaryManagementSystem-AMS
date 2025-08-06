namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.DeleteApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.UpdateApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaries;
using ApiaryManagementSystem.Application.Features.Apiaries.Queries.GetApiaryById;
using ApiaryManagementSystem.Application.Features.Hives.Queries;
using ApiaryManagementSystem.Application.Features.Hives.Queries.GetHivesByApiaryId;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Apiaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(this.GetApiaries)
            .MapGet(this.GetApiaryById, "{id}")
            .MapGet(this.GetHivesByApiaryId, "{apiaryId}/hives")
            .MapPost(this.CreateApiary)
            .MapPut(this.UpdateApiary, "{id}")
            .MapDelete(this.DeleteApiary, "{id}");
    }
    public async Task<PaginatedList<ApiaryModel>> GetApiaries(ISender sender, string? searchTerm, int page = 1, int pageSize = 10)
        => await sender.Send(new GetApiariesQuery
        {
            SearchTerm = searchTerm,
            Page = page,
            PageSize = pageSize
        });

    public async Task<ApiaryModel> GetApiaryById(ISender sender, Guid id)
        => await sender.Send(new GetApiaryByIdQuery() { ApiaryId = id });

    public async Task<IReadOnlyCollection<HiveModel>> GetHivesByApiaryId(ISender sender, Guid apiaryId)
        => await sender.Send(new GetHivesByApiaryIdQuery() { ApiaryId = apiaryId });

    public async Task<IResult> CreateApiary(ISender sender, CreateApiaryCommand command)
    {
        var apiaryId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetApiaryById), new { id = apiaryId }, apiaryId);
    }

    public async Task<IResult> UpdateApiary(ISender sender, Guid id, UpdateApiaryCommand command)
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

    public async Task<IResult> DeleteApiary(ISender sender, Guid id)
    {
        await sender.Send(new DeleteApiaryCommand() { Id = id });

        return Results.NoContent();
    }
}
