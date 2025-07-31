using TJ_API.Services;
using TJ_API.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

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

app.MapFallback(async ctx =>
{
    ctx.Response.StatusCode = 500;
    await ctx.Response.WriteAsJsonAsync(new ErrorMessage("Muja! Check your arguments. Monnimoka."));
});

app.Run();