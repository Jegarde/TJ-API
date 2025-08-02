using Microsoft.AspNetCore.Mvc;
using TJ_API.Models;
using TJ_API.Services;

namespace TJ_API.Controllers;

record TJRequest(int Period, int Year, int Duration);

[ApiController]
public class TJController : ControllerBase
{
    [HttpGet("{period:int}/{year:int}/{duration:int}")]
    public IActionResult TJ(int period, int year, int duration)
    {
        TJRequest req = new(period, year, duration);
        return GenerateResponse(req);
    }


    private bool ValidateRequest(TJRequest req, out ObjectResult error)
    {
        error = BadRequest(new ErrorMessage("This shouldn't appear! Aamuja."));

        // Years must be in bounds (ignore if 2 digits like 25 meaning 2025)
        if ((req.Year < 1900 || req.Year > 3000) && Utility.IntegerLength(req.Year) != 2)
        {
            error = BadRequest(new ErrorMessage("Year must be 1900 <= year <= 3000 or 2 digits like 25 (2025)."));
            return false;
        }

        // Period must be 1 or 2 (1/25 or 2/25)
        if (req.Period != 1 && req.Period != 2)
        {
            error = BadRequest(new ErrorMessage("Period must be 1 or 2. (1/25 & 2/25)"));
            return false;
        }

        return true;
    }

    /// <summary>
    /// Returns API response containing TJ. Returns error message if validation fails.
    /// </summary>
    private ObjectResult GenerateResponse(TJRequest req)
    {
        if (!ValidateRequest(req, out var error))
            return error;

        // If year is given as (example) 25, add 2000 to it (2025)
        int year = req.Year;
        if (Utility.IntegerLength(year) == 2)
            // Assume it's the 21 century
            year += 2000;

        TJ tj = TJGenerator.GenerateTJ(req.Period, year, req.Duration);
        return Ok(tj);
    }
}