namespace TJControllerFile;

public static class TJController
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/", () => "This is a GET");
    }
}