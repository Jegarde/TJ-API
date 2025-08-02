namespace TJ_API.Services;

public static class Utility
{
    private static readonly TimeZoneInfo FinnishTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");

    /// <summary>
    /// Generates a DateTime with the Finnish timezone
    /// </summary>
    public static DateTime GenerateFinnishDate(int year, int month, int day)
    {
        DateTime date = new(year, month, day);
        return TimeZoneInfo.ConvertTimeFromUtc(date, FinnishTimeZone);
    }

    /// <summary>
    /// Calculates the length of an integer.
    /// Ex. 12345 -> 5
    /// </summary>
    public static int IntegerLength(int num)
    {
        int abs = (num == int.MinValue) ? int.MaxValue : Math.Abs(num);
        return (num == 0) ? 1 : (int)Math.Floor(Math.Log10(abs)) + 1;
    }

    /// <summary>
    /// Converts given DateTime into a Unix timestamp long integer
    /// </summary>
    public static long GetUnixTimestamp(DateTime date)
    {
        return ((DateTimeOffset)date).ToUnixTimeSeconds();
    }
}