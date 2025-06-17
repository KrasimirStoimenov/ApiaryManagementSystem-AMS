namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Diseases.Commands.CreateDisease;
using ApiaryManagementSystem.Application.Features.Diseases.Commands.DeleteDisease;
using ApiaryManagementSystem.Application.Features.Diseases.Commands.UpdateDisease;
using ApiaryManagementSystem.Application.Features.Diseases.Queries;
using ApiaryManagementSystem.Application.Features.Diseases.Queries.GetDiseaseById;
using ApiaryManagementSystem.Application.Features.Diseases.Queries.GetDiseases;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;

public sealed class Diseases : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(this.GetDiseases)
            .MapGet(this.GetDiseaseById, "{id}")
            .MapPost(this.CreateDisease)
            .MapPut(this.UpdateDisease, "{id}")
            .MapDelete(this.DeleteDisease, "{id}");
    }

    public async Task<PaginatedList<DiseaseModel>> GetDiseases(ISender sender, int page = 1, int pageSize = 10)
        => await sender.Send(new GetDiseasesQuery
        {
            Page = page,
            PageSize = pageSize
        });

    public async Task<DiseaseModel> GetDiseaseById(ISender sender, Guid id)
        => await sender.Send(new GetDiseaseByIdQuery() { DiseaseId = id });

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
