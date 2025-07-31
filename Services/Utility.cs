namespace TJ_API.Services;

public static class Utility
{
    /// <summary>
    /// Calculates the length of an integer.
    /// Ex. 12345 -> 5
    /// </summary>
    public static int IntegerLength(int num)
    {
        int abs = (num == int.MinValue) ? int.MaxValue : Math.Abs(num);
        return (num == 0) ? 1 : (int)Math.Floor(Math.Log10(abs)) + 1;
    }
}