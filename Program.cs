using Microsoft.OpenApi.Models;
using TJ_API.Controllers;
using TJ_API.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

SwaggerHandler.BuilderInit(builder);

WebApplication app = builder.Build();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    SwaggerHandler.Run(app);
}

app.MapControllers();

app.Run();