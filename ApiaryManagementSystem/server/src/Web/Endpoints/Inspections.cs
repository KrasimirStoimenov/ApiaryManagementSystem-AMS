namespace ApiaryManagementSystem.Web.Endpoints;
using ApiaryManagementSystem.Application.Common.Models;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.DeleteInspection;
using ApiaryManagementSystem.Application.Features.Inspections.Commands.UpdateInspection;
using ApiaryManagementSystem.Application.Features.Inspections.Queries;
using ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspectionById;
using ApiaryManagementSystem.Application.Features.Inspections.Queries.GetInspections;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Inspections : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(this.GetInspections)
            .MapGet(this.GetInspectionById, "{id}")
            .MapPost(this.CreateInspection)
            .MapPut(this.UpdateInspection, "{id}")
            .MapDelete(this.DeleteInspection, "{id}");
    }
    public async Task<PaginatedList<InspectionModel>> GetInspections(ISender sender, int page = 1, int pageSize = 10)
        => await sender.Send(new GetInspectionsQuery
        {
            Page = page,
            PageSize = pageSize
        });

    public async Task<InspectionModel> GetInspectionById(ISender sender, Guid id)
        => await sender.Send(new GetInspectionByIdQuery() { InspectionId = id });

    public async Task<IResult> CreateInspection(ISender sender, CreateInspectionCommand command)
    {
        var inspectionId = await sender.Send(command);

        return Results.CreatedAtRoute(nameof(GetInspectionById), new { id = inspectionId }, inspectionId);
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

        return Results.NoContent();
    }
}
