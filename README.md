
# 🌡️🌤️ Open-Meteo Dotnet Library
![GitHub](https://img.shields.io/github/license/AlienDwarf/open-meteo-dotnet)

A .Net Standard 2.1 library for the [Open-Meteo](https://open-meteo.com) API.

## ❕ Information

This project is still in development. There will be major changes in the codebase.


## 💻 Usage

### Zero config example:
```c#
using OpenMeteo;

static void Main()
{
    RunAsync().GetAwaiter().GetResult();
}

static async Task RunAsync()
{
    OpenMeteoClient client = new OpenMeteoClient();
    var weatherData = await client.QueryAsync("Tokyo");
    Console.WriteLine("Weather in Tokyo: " + weatherData.Current_Weather.Temperature + "°C");
    
    // Output: "Weather in Tokyo: 28.1°C
}
```

### Adding options:
```c#
using OpenMeteo;

static void Main()
{
    RunAsync().GetAwaiter().GetResult();
}

static async Task RunAsync()
{
    OpenMeteoClient client = new OpenMeteoClient();
    WeatherForecastOptions options = new WeatherForecastOptions();
    options.Current_Weather = true;
    options.Latitude = 35.6895f; 
    options.Longitude = 139.69171f; // For Tokyo

    WeatherForecast weatherData = await client.QueryAsync(options);
    Console.WriteLine("Weather in Tokyo: " + weatherData.CurrentWeather.Temperature + "°C");

    // Output: "Weather in Tokyo: 28.1°C
}
```
### Getting Geocoding API data and reuse it for weatherforecast:
```c#
using OpenMeteo;

static void Main()
{
    RunAsync.GetAwaiter().GetResult();
}

static async Task RunAsync()
{
    OpenMeteoClient client = new OpenMeteoClient();
    GeocodingOptions geocodingOptions = new OpenMeteo.GeocodingOptions("Tokyo");
    var cityDataResults = await client.GetCityGeocodingDataAsync(geocodingOptions);
    var cityData = cityDataResults.Cities[0];

    Console.WriteLine(cityData.Name + "is a city in " + cityData.Country + "with a population of " + cityData.Population + " people.");
    // or Console.WriteLine(cityDataResults.Cities[0].Name + " is a city in " + cityData.Cities[0].Country + " with a population of " + cityData.Cities[0].Population + " people.");
    // Output: "Tokyo is a city in Japan with a population of 8336599 people."

    var weatherData = await client.QueryAsync(geocodingOptions);
    Console.WriteLine("Weather in " + cityData.Name + "is " + weatherData.CurrentWeather.Temperature + "°C");
    
    // Output: Weather in Tokyo is 25°C.
}
```


## License

This project is open-source under the [MIT](https://github.com/AlienDwarf/open-meteo-dotnet/blob/master/LICENSE.txt) license.

## Appendix

This library uses the public and free available [Open-Meteo](https://open-meteo.com) API servers.
See also:
- [omgo - Open Meteo SDK written in Go ](https://github.com/HectorMalot/omgo)
- [OpenMeteoPy](https://github.com/m0rp43us/openmeteopy)
- [Open-Meteo Kotlin Library](https://github.com/open-meteo/open-meteo-api-kotlin)

