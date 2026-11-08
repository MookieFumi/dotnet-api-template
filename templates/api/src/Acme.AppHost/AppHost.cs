var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Acme_Api>("api");
//#if (worker)
builder.AddProject<Projects.Acme_Worker>("worker");
//#endif

builder.Build().Run();
