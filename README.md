
# 🌡️🌤️ Open-Meteo Dotnet Library
[![build and test](https://github.com/AlienDwarf/open-meteo-dotnet/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/AlienDwarf/open-meteo-dotnet/actions/workflows/build-and-test.yml)
[![GitHub license](https://img.shields.io/github/license/AlienDwarf/open-meteo-dotnet)](https://github.com/AlienDwarf/open-meteo-dotnet/blob/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/openmeteo.dotnet)](https://www.nuget.org/packages/OpenMeteo.dotnet)

A .Net Standard library for the [Open-Meteo](https://open-meteo.com) API.
# 2.0.0 is not compatible with lower versions like 0.2.x!

## ❕ Information

This project is still in development. There *will* be major changes in the codebase.

## 🎯 Roadmap
- Documentation and wiki
- Throw exceptions instead of returning *null* (v0.2)

## 🔨 Installation/Build

### NuGet
[NuGet Package](https://www.nuget.org/packages/OpenMeteo.dotnet/)

Use NuGet Package Manager GUI. Or use NuGet CLI:

```bash
dotnet add package OpenMeteo.dotnet
```

### Build
Alternatively you can build this library on your own.

1. Clone this repo:
```bash
git clone https://github.com/AlienDwarf/open-meteo-dotnet
```

2. Open the project and build it. The build process will create a .dll file in ```/bin/[CONFIGURATION]/netstandard2.1/```

3. Add a reference in your own project to the .dll in your own project.

4. Add ```using OpenMeteo;``` to your class.

## 💻 Usage

### Minimal:
```cs
using OpenMeteo;

static void Main()
{
    RunAsync().GetAwaiter().GetResult();
}

static async Task RunAsync()
{
    // Before using the library you have to create a new client. 
    // Once created you can reuse it for every other api call you are going to make. 
    // There is no need to create multiple clients.
    OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

    // Make a new api call to get the current weather in tokyo
    WeatherForecast weatherData = await client.QueryAsync("Tokyo");

    // Output the current weather to console
    Console.WriteLine("Weather in Tokyo: " + weatherData.Current.Temperature + weatherData.CurrentUnits.Temperature);
    
    // Output: "Weather in Tokyo: 28.1°C
}
```
*For more examples visit the [Wiki](https://github.com/AlienDwarf/open-meteo-dotnet/wiki/Usage#examples) example page.*

## License

This project is open-source under the [MIT](https://github.com/AlienDwarf/open-meteo-dotnet/blob/master/LICENSE.txt) license.

## Appendix

This library uses the public and free available [Open-Meteo](https://open-meteo.com) API servers.
See also:
- [omgo - Open Meteo SDK written in Go ](https://github.com/HectorMalot/omgo)
- [OpenMeteoPy](https://github.com/m0rp43us/openmeteopy)
- [Open-Meteo Kotlin Library](https://github.com/open-meteo/open-meteo-api-kotlin)

