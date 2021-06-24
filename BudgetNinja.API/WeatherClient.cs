using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BudgetNinjaAPI
{
  public class WeatherClient
  {
    private readonly HttpClient httpClient;

    private readonly ServiceSettings settings;

    public WeatherClient(HttpClient client, IOptions<ServiceSettings> options)
    {
      httpClient = client ?? throw new ArgumentNullException(nameof(client));
      settings = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public record Weather(string description);
    public record Main(decimal temp);

    public record Forecast(Weather[] weather, Main main, long dt);

    public async Task<Forecast> GetCurrentWeatherAsync(string city)
    {
      var query = $"https://{settings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={settings.ApiKey}&units=metric";
      var forecast = await httpClient.GetFromJsonAsync<Forecast>(query);
      return forecast;
    }
  }
}