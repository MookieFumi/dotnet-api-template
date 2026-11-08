using System.Net;
using System.Net.Http.Json;

using Launchpad.Api.Features.V1.Greetings.GetGreeting;

using Microsoft.AspNetCore.Mvc.Testing;

namespace Launchpad.Api.Tests.Features;

public sealed class GetGreetingTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Returns_a_greeting_for_a_name()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/greetings/Ada");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadFromJsonAsync<GetGreetingResponse>();
        Assert.Equal("Hello, Ada!", body?.Message);
    }

    [Fact]
    public async Task Rejects_a_blank_name_with_problem_details()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/greetings/%20");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
    }
}
