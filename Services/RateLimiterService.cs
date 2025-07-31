using System.Threading.RateLimiting;
using TJ_API.Models;

namespace TJ_API.Services;

public static class RateLimiterService
{
    const int RateLimitSeconds = 60;
    const int RateLimitPermit = 50;

    public static void RateLimitInit(WebApplicationBuilder builder)
    {
        builder.Services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = RateLimitPermit,
                    Window = TimeSpan.FromSeconds(RateLimitSeconds)
                }));

            options.OnRejected = async (ctx, cancellationToken) =>
            {
                ctx.HttpContext.Response.StatusCode = options.RejectionStatusCode;
                ctx.HttpContext.Response.Headers.RetryAfter = RateLimitSeconds.ToString();

                await ctx.HttpContext.Response.WriteAsJsonAsync(new ErrorMessage("Rate limit exceeded. Please try again later."), cancellationToken);
            };
        });
    }
}