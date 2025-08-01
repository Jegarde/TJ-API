using TJ_API.Models;
using TJ_API.Services;

namespace TJ_API.Services;

public static class TJGenerator
{
    /// <summary>
    /// Arrival patches mapped with their starting dates.
    /// </summary>
    private static readonly Dictionary<string, DateTime> StartingDates = new()
    {
        {"1/2016", Utility.GenerateFinnishDate(2016, 1, 4)},
        {"2/2016", Utility.GenerateFinnishDate(2016, 7, 4)},
        {"1/2017", Utility.GenerateFinnishDate(2017, 1, 2)},
        {"2/2017", Utility.GenerateFinnishDate(2017, 7, 3)},
        {"1/2018", Utility.GenerateFinnishDate(2018, 1, 8)},
        {"2/2018", Utility.GenerateFinnishDate(2018, 7, 9)},
        {"1/2019", Utility.GenerateFinnishDate(2019, 1, 7)},
        {"2/2019", Utility.GenerateFinnishDate(2019, 7, 8)},
        {"1/2020", Utility.GenerateFinnishDate(2020, 1, 6)},
        {"2/2020", Utility.GenerateFinnishDate(2020, 7, 6)},
        {"1/2021", Utility.GenerateFinnishDate(2021, 1, 4)},
        {"2/2021", Utility.GenerateFinnishDate(2021, 7, 5)},
        {"1/2022", Utility.GenerateFinnishDate(2022, 1, 3)},
        {"2/2022", Utility.GenerateFinnishDate(2022, 7, 4)},
        {"1/2023", Utility.GenerateFinnishDate(2023, 1, 2)},
        {"2/2023", Utility.GenerateFinnishDate(2023, 7, 3)},
        {"1/2024", Utility.GenerateFinnishDate(2024, 1, 8)},
        {"2/2024", Utility.GenerateFinnishDate(2024, 7, 8)},
        {"1/2025", Utility.GenerateFinnishDate(2025, 1, 6)},
        {"2/2025", Utility.GenerateFinnishDate(2025, 7, 7)},
        {"1/2026", Utility.GenerateFinnishDate(2026, 1, 5)},
        {"2/2026", Utility.GenerateFinnishDate(2026, 7, 6)},
    };

    private static string GenerateArrivalPatch(int period, int year)
    {
        return $"{period}/{year}";
    }

    public static TJ GenerateTJ(int period, int year, int duration)
    {
        if (!StartingDates.TryGetValue(GenerateArrivalPatch(period, year), out DateTime beginningDate))
            if (period == 1)
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
            Days: Math.Round(tjSpan.TotalDays, 2),
            Weeks: Math.Round(tjSpan.TotalDays / 7f, 2),
            Months: Math.Round(tjSpan.TotalDays / 30f, 2),
            Seconds: Math.Round(tjSpan.TotalSeconds, 1),
            StartDate: Utility.GetUnixTimestamp(beginningDate),
            ReturnDate: Utility.GetUnixTimestamp(endingDate)
        );
    }
}
