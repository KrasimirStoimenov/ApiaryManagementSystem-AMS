var builder = DistributedApplication.CreateBuilder(args);

var apiProject = builder.AddProject<Projects.Web>("apiaryManagementSystem-api");

builder.AddNpmApp("apiaryManagementSystem-client", "../../client", scriptName: "dev")
    .WithReference(apiProject)
    .WaitFor(apiProject)
    .WithHttpEndpoint(targetPort: 5173)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
