using Launchpad.Api.Features;
using Launchpad.Api.Features.V1;

var builder = WebApplication.CreateBuilder(args);

//#if (aspire)
builder.AddServiceDefaults();

//#endif
// Every error the framework writes (validation, unhandled exceptions) becomes application/problem+json.
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddFeatureHandlers();

var app = builder.Build();

app.UseExceptionHandler();

//#if (aspire)
app.MapDefaultEndpoints();
//#endif
app.MapOpenApi();
app.MapV1Endpoints();

app.Run();

/// <summary>
/// Makes the entry point visible to <c>WebApplicationFactory</c> in the test project.
/// </summary>
public partial class Program;
