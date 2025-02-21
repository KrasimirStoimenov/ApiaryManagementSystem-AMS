var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Web>("apiaryManagementSystem-api");

builder.Build().Run();
