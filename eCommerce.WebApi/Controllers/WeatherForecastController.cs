using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebApi.Controllers
{
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly Microsoft.Extensions.Logging.ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(Microsoft.Extensions.Logging.ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public System.Collections.Generic.IEnumerable<WeatherForecast> Get()
        {
            return System.Linq.Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = System.DateTime.Now.AddDays(index),
                    TemperatureC = System.Random.Shared.Next(-20, 55),
                    Summary = Summaries[System.Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}