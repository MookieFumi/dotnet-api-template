namespace Launchpad.Api.Features.V1.Greetings.GetGreeting;

public static class GetGreetingEndpoint
{
    public static void Map(RouteGroupBuilder group) =>
        group.MapGet("/greetings/{name}", Handle)
            .WithName("GetGreeting")
            .WithTags("Greetings")
            .WithSummary("Greets someone by name.");

    private static IResult Handle(string name, GetGreetingHandler handler)
    {
        var response = handler.Handle(name);

        return response is null
            ? TypedResults.Problem(statusCode: StatusCodes.Status400BadRequest, title: "The name cannot be empty.")
            : TypedResults.Ok(response);
    }
}
