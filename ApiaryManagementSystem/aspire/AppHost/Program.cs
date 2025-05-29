var builder = DistributedApplication.CreateBuilder(args);

var apiProject = builder.AddProject<Projects.Web>("apiaryManagementSystem-api");

builder.AddNpmApp("apiaryManagementSystem-client", "../../client", scriptName: "dev")
    .WithReference(apiProject)
    .WaitFor(apiProject)
    .WithHttpEndpoint(port: 5173, targetPort: 5173, isProxied: false)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
