using AMS.Application;
using AMS.Domain;
using AMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddDomain()
    .AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.

app
    .UseHttpsRedirection()
    .UseAuthorization();


app.Run();
