using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Minsk", "Kiev", "New York", "Warsaw", "Berlin", "Lviv"
        };

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastWithCity>> Get(
          [FromServices] WeatherClient client)
        {
            var weather = await client.GetWeatherAsync();

            var rng = new Random();
            return weather.Select(i => new WeatherForecastWithCity
            {
                City = Cities[rng.Next(0, 6)],
                Date = i.Date,
                TemperatureC = i.TemperatureC,
                Summary = i.Summary
            })
            .ToArray();
        }
    }
}
