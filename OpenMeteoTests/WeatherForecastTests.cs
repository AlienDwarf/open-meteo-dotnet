using System.Globalization;
using System.Threading;
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
            
            WeatherForecast weatherData = await client.QueryAsync(1.125f, 2.25f);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);

            Assert.AreEqual(1.125f, weatherData.Latitude);
            Assert.AreEqual(2.25f, weatherData.Longitude);
        }

        [TestMethod]
        public async Task Latitude_Longitude_Test_With_French_Culture()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            OpenMeteoClient client = new OpenMeteoClient();
            
            WeatherForecast weatherData = await client.QueryAsync(1.125f, 2.25f);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);

            Assert.AreEqual(1.125f, weatherData.Latitude);
            Assert.AreEqual(2.25f, weatherData.Longitude);
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
                0f, 
                0f, 
                TemperatureUnitType.celsius, 
                WindspeedUnitType.kmh, 
                PrecipitationUnitType.mm, 
                "GMT", 
                null, 
                null, 
                null,
                null,
                TimeformatType.iso8601, 
                0,
                "2022-08-30",
                "2022-08-31",
                null,
                CellSelectionType.nearest
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
                Daily = DailyOptions.All,
                Models = WeatherModelOptions.All,
                Current = CurrentOptions.All,
                Minutely15 = Minutely15Options.All
            };

            var res = await client.QueryAsync(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Hourly);
            Assert.IsNotNull(res.HourlyUnits);
            Assert.IsNotNull(res.Daily);
            Assert.IsNotNull(res.DailyUnits);
            Assert.IsNotNull(res.Hourly.Cloudcover_1000hPa_best_match);
            Assert.IsNotNull(res.Current);
            Assert.IsNotNull(res.Minutely15);
        }

        [TestMethod]
        public void WeatherForecast_With_All_Options_Sync_Test()
        {
            OpenMeteoClient client = new();
            WeatherForecastOptions options = new()
            {
                Hourly = HourlyOptions.All,
                Daily = DailyOptions.All,
                Current = CurrentOptions.All,
                Minutely15 = Minutely15Options.All,
            };

            var res = client.Query(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Hourly);
            Assert.IsNotNull(res.HourlyUnits);
            Assert.IsNotNull(res.Daily);
            Assert.IsNotNull(res.DailyUnits);
            Assert.IsNotNull(res.Current);
            Assert.IsNotNull(res.Minutely15);
        }
    }
}
