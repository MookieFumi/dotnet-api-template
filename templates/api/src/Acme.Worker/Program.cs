using Acme.Worker;

var builder = Host.CreateApplicationBuilder(args);

//#if (aspire)
builder.AddServiceDefaults();

//#endif
builder.Services.AddHostedService<HeartbeatWorker>();

builder.Build().Run();
