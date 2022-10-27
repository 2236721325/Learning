using GuidGenerator.GuidGenerators;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GuidGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGuidGenerator _GuidGenerator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGuidGenerator guidGenerator)
        {
            _logger = logger;
            _GuidGenerator = guidGenerator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public Guid GetGuid()
        {
            return _GuidGenerator.Create();
        }
    }
}