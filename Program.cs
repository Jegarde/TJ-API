using TJ_API.Services;
using TJ_API.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Setup logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Setup rate limits
RateLimiterService.RateLimitInit(builder);

// Setup Swagger docs
SwaggerHandler.BuilderInit(builder);

WebApplication app = builder.Build();
app.UseRouting();

// Let's not provide the blueprint to our API to hackers! 👻
if (app.Environment.IsDevelopment())
{
    SwaggerHandler.Run(app);
}

app.MapControllers();
app.UseRateLimiter();

app.MapFallback(async ctx =>
{
    ctx.Response.StatusCode = 500;
    app.Logger.LogError("Internal Server Error!");
    await ctx.Response.WriteAsJsonAsync(new ErrorMessage("Muja! Check your arguments. Monnimoka."));
});

app.Run();