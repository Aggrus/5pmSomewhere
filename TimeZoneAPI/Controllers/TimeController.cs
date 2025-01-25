using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TimeZoneConverter;

[ApiController]
[Route("api/time")]
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
            if (localTime.Hour == 17)
            {
                string timeThere = timeZone.DisplayName.Split(')')[1] + " --> " + localTime.Hour + ":" + localTime.Minute;
                results.Add(timeThere);
                Console.WriteLine(results.Last());

            }
        }
       
        return Ok(new { locations = results });
    }
}
