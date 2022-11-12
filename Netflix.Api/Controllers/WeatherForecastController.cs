using Microsoft.AspNetCore.Mvc;
using Netflix.Api.Models;

namespace Netflix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<WeatherForecast> weathers;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
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

    [HttpGet("GetNome/{temperatura}")]
    public IActionResult Nome(int temperatura)
    {
        if(temperatura == 0) {
            return BadRequest("TÁ MUITO FRIO");
        }

        return Ok(new WeatherForecast() { TemperatureC = temperatura });
    } 

    [HttpPost("")]
    public IActionResult Post([FromBody] WeatherForecast? weather)
    {
        if(weather is null) {
            return BadRequest();
        }

        return Ok();
    } 
}
