using Acme.Api.Features.V1.Greetings.GetGreeting;

namespace Acme.Api.Features.V1;

public static class V1Endpoints
{
    public static IEndpointRouteBuilder MapV1Endpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1");

        GetGreetingEndpoint.Map(group);

        return app;
    }
}
