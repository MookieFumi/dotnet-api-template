namespace Acme.Api.Features.V1.Greetings.GetGreeting;

/// <summary>
/// The smallest possible slice: no database, one rule. Replace it with your first real feature.
/// </summary>
public sealed class GetGreetingHandler
{
    public GetGreetingResponse? Handle(string name)
    {
        return string.IsNullOrWhiteSpace(name)
            ? null
            : new GetGreetingResponse($"Hello, {name.Trim()}!");
    }
}
