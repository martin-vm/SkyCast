namespace SkyCast.Services;

public record WeatherDto(string Name, MainData Main, IEnumerable<WeatherInfo> Weather);
public record MainData(double Temp, double Humidity);
public record WeatherInfo(string Description, string Icon);