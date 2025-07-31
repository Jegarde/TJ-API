using TJ_API.Models;

namespace TJ_API.Services;

public static class TJService
{
    public static int GenerateTJ()
    {
        ServiceDates service = new(firstHalf: true, 2025, 255);

        TimeSpan tj = service.endingDate - DateTime.Now;
        return tj.Days;
    }
}