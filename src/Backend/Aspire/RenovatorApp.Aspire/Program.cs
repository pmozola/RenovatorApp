using Projects;

var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<RenovatorApp_API>("API");

builder.Build().Run();