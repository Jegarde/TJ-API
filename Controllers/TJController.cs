using Microsoft.AspNetCore.Mvc;
using TJ_API.Models;
using TJ_API.Services;

namespace TJ_API.Controllers;

[ApiController]
public class TJController : ControllerBase
{
    [HttpGet("{period:int}/{year:int}/{duration:int}")]
    public IActionResult TJ(int period, int year, int duration)
    {
        ServiceDates service = new(period == 1, year, duration);

        TimeSpan tj = service.endingDate - DateTime.Now;
        return Ok(tj.Days);
    }
}