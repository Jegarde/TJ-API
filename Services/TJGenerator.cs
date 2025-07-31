using TJ_API.Models;

namespace TJ_API.Services;

public static class TJGenerator
{
    public static TJ GenerateTJ(bool firstPeriod, int year, int duration)
    {
        DateTime beginningDate;
        if (firstPeriod)
        {
            // Assume first period starts January 6th
            beginningDate = new(year, 1, 6);
        }
        else
        {
            // Assume second period starts July 7th
            beginningDate = new(year, 7, 7);
        }
        DateTime endingDate = beginningDate.AddDays(duration);
        TimeSpan tjSpan = endingDate - DateTime.Now;

        return new TJ(
            Days: tjSpan.Days,
            Weeks: Math.Round((double)tjSpan.Days / 7f, 2),
            Months: Math.Round((double)tjSpan.Days / 30f, 2),
            Seconds: Math.Ceiling(tjSpan.TotalSeconds)
        );
    }
}
