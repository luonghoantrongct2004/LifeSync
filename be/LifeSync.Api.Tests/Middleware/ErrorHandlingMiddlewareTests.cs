using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

public class ErrorHandlingMiddlewareTests
{
    [Fact]
    public async Task Middleware_ReturnsJsonError_OnException()
    {
        var builder = new WebHostBuilder()
            .Configure(app =>
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
                app.Run(_ => throw new Exception("Test error"));
            });

        using var server = new TestServer(builder);
        using var client = server.CreateClient();

        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Test error", content);
        Assert.Contains("application/json", response.Content.Headers.ContentType!.ToString());
    }
} 