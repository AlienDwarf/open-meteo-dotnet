using System.Globalization;
using System.Linq;
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
        public void WeatherForecast_With_All_Options_Test()
        {
            WeatherForecastOptions options = new()
            {
                Hourly = HourlyOptions.All,
                Daily = DailyOptions.All,
                Models = WeatherModelOptions.All,
                Current = CurrentOptions.All,
                Minutely15 = Minutely15Options.All
            };

            Assert.IsTrue(HourlyOptions.All.Parameter.All(p => options.Hourly.Parameter.Contains(p)));
            Assert.IsTrue(DailyOptions.All.Parameter.All(p => options.Daily.Parameter.Contains(p)));
            Assert.IsTrue(WeatherModelOptions.All.Parameter.All(p => options.Models.Parameter.Contains(p)));
            Assert.IsTrue(CurrentOptions.All.Parameter.All(p => options.Current.Parameter.Contains(p)));
            Assert.IsTrue(Minutely15Options.All.Parameter.All(p => options.Minutely15.Parameter.Contains(p)));
        }
    }
}
