using Microsoft.AspNetCore.Mvc;
using TJ_API.Models;
using TJ_API.Services;

namespace TJ_API.Controllers;

[ApiController]
public class TJController : ControllerBase
{
    /// Avoid validating period by simply having 1 & 2 as routes.
    /// I'd imagine this makes the API the slightest bit more performant.
    /// But I recognize that validating the period isn't very performant-heavy.

    [HttpGet("1/{year:int}/{duration:int}")]
    public IActionResult TJ_FirstPeriod(int year, int duration)
    {
        return GenerateTJ(firstPeriod: true, year, duration);
    }

    [HttpGet("2/{year:int}/{duration:int}")]
    public IActionResult TJ_SecondPeriod(int year, int duration)
    {
        return GenerateTJ(firstPeriod: false, year, duration);
    }

    private OkObjectResult GenerateTJ(bool firstPeriod, int year, int duration)
    {
        // If year is given as (example) 25, add 2000 to it (2025)
        if (Utility.IntegerLength(year) == 2)
            // Assume it's the 21 century
            year += 2000;

        ServiceDates service = new(firstPeriod, year, duration);

        TimeSpan tj = service.endingDate - DateTime.Now;
        return Ok(tj.Days);
    }
}