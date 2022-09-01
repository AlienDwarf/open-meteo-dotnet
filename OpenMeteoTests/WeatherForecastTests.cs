using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;

namespace OpenMeteoTests
{
    [TestClass]
    public class WeatherForecastTests
    {
        [TestMethod]
        public async Task Only_Location_Name_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            string location = "Tokyo";
            WeatherForecast weatherData = await client.QueryAsync(location);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);
        }

        [TestMethod]
        public async Task Latitude_Longitude_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            
            WeatherForecast weatherData = await client.QueryAsync(1f, 2f);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);

            Assert.AreEqual(1f, weatherData.Latitude);
            Assert.AreEqual(2f, weatherData.Longitude);
        }

        [TestMethod]
        public async Task GeocodingOptions_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            GeocodingOptions options = new GeocodingOptions("Tokyo");
            WeatherForecast weatherData = await client.QueryAsync(options);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);
        }

        [TestMethod]
        public async Task WeatherForecast_With_WeatherForecastOptions_Test()
        {
            OpenMeteoClient client = new();
            WeatherForecastOptions weatherForecast = new();

            var res = await client.QueryAsync(weatherForecast);

            Assert.IsNotNull(res);
            Assert.AreEqual(0f, res.Latitude);
            Assert.AreEqual(0f, res.Longitude);
        }

        [TestMethod]
        public async Task WeatherForecast_With_String_And_Options_Test()
        {
            OpenMeteoClient client = new();
            var options = new WeatherForecastOptions(
                0, 
                0, 
                TemperatureUnitType.celsius, 
                WindspeedUnitType.kmh, 
                PrecipitationUnitType.mm, 
                "GMT", 
                null, 
                null, 
                true, 
                TimeformatType.iso8601, 
                0,
                "2022-08-30",
                "2022-08-31"
                );

            var res = await client.QueryAsync("Tokyo", options);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public async Task WeatherForecast_With_All_Options_Test()
        {
            OpenMeteoClient client = new();
            WeatherForecastOptions options = new()
            {
                Hourly = HourlyOptions.All,
                Daily = DailyOptions.All
            };

            var res = await client.QueryAsync(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Hourly);
            Assert.IsNotNull(res.Hourly_units);
            Assert.IsNotNull(res.Daily);
            Assert.IsNotNull(res.Daily_units);
        }
    }
}
