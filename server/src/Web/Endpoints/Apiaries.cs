﻿namespace ApiaryManagementSystem.Web.Endpoints;

using ApiaryManagementSystem.Application.Features.Apiaries.Commands.CreateApiary;

public class Apiaries : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateApiary);
    }

    public Task<Guid> CreateApiary(ISender sender, CreateApiaryCommand command)
    {
        return sender.Send(command);
    }
}