using Microsoft.OpenApi.Models;
using TJControllerFile;
using SwaggerService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
SwaggerHandler.BuilderInit(builder);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    SwaggerHandler.Run(app);
}

TJController.Map(app);

app.Run();