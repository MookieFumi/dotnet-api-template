var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Launchpad_Api>("api");
//#if (worker)
builder.AddProject<Projects.Launchpad_Worker>("worker");
//#endif

builder.Build().Run();
