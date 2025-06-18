using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services;

public class WeatherService
{
    private readonly HttpClient _http;
    private readonly string _key;
    private const string baseURL = "https://api.openweathermap.org/data/2.5";

    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _key = config["OPENWEATHER_KEY"] ?? "6d0a6353ba4e7b76bdabb64abea3e214";
    }

    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";
        return await _http.GetFromJsonAsync<WeatherDto>(url);
    }
}