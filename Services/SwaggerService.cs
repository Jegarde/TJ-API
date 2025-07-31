using Microsoft.OpenApi.Models;

namespace TJ_API.Services;

public static class SwaggerHandler
{
    public static void BuilderInit(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TJ API", Description = "Tänään jäljellä!", Version = "v1" });
        });
    }

    public static void Run(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TJ API V1");
        });
    }
}