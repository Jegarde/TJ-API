namespace TJ_API.Models;

public enum Duration
{
    Short = 165,
    Mid = 255,
    Long = 347
}

public struct ServiceDates
{
    /// <summary>
    /// True = 1/{year}
    /// False = 2/{year}
    /// </summary>
    public bool firstHalf;
    public int year;
    public Duration duration;

    public DateTime beginningDate;
    public DateTime endingDate;

    private void CalculateBeginningDate()
    {
        if (firstHalf)
        {
            beginningDate = new(year, 1, 6);
        }
        else
        {
            beginningDate = new(year, 7, 7);
        }
    }

    private void CalculateEndingDate()
    {
        endingDate = beginningDate.AddDays((int)duration);
    }

    public ServiceDates(bool firstHalf, int year, Duration duration)
    {
        this.firstHalf = firstHalf;
        this.year = year;
        this.duration = duration;

        CalculateBeginningDate();
        CalculateEndingDate();
    }
}