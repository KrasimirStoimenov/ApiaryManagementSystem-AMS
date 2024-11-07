namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.DeleteApiary;
using ApiaryManagementSystem.Application.Features.Apiaries.Commands.UpdateApiary;
using ApiaryManagementSystem.Web.Infrastructure;
using MediatR;

public class Apiaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateApiary)
            .MapPut(UpdateApiary, "{id}")
            .MapDelete(DeleteApiary, "{id}");
    }

    public async Task<Guid> CreateApiary(ISender sender, CreateApiaryCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateApiary(ISender sender, Guid id, UpdateApiaryCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
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
