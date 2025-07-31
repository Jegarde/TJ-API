using TJ_API.Services;

namespace TJ_API.Controllers;

public static class TJController
{
    public static void Map(WebApplication app)
    {
        int tj = TJService.GenerateTJ();
        app.MapGet("/", () => tj);
    }
}