using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BudgetNinjaAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;

    private readonly WeatherClient weatherClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherClient client)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      weatherClient = client ?? throw new ArgumentNullException(nameof(client));
    }

    [HttpGet]
    [Route("{city}")]
    public async Task<WeatherForecast> Get(string city)
    {
      var forecast = await weatherClient.GetCurrentWeatherAsync(city);

      return new WeatherForecast
      {
        Summary = forecast.weather[0].description,
        TemperatureC = (int)forecast.main.temp,
        Date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime
      };
    }
  }
}