using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TimeZoneConverter;

[ApiController]
[Route("api/[controller]")]
public class TimeController : ControllerBase
{
    [HttpGet("where-is-5pm")]
    public IActionResult WhereIs5PM()
    {
        var currentTimeUtc = DateTime.UtcNow;
        var timeZones = TimeZoneInfo.GetSystemTimeZones();
        var results = new List<string>();

        foreach (var timeZone in timeZones)
        {
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(currentTimeUtc, timeZone);
            if (localTime.Hour == 17 && localTime.Minute == 0)
            {
                results.Add(timeZone.DisplayName);
            }
        }

        return Ok(new { locations = results });
    }
}
