using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;
using System.Text.Json;

namespace OpenMeteoTests
{
    [TestClass]
    public class WeatherForecastOptionsTests
    {
        [TestMethod]
        public void Empty_WeatherForecastOptions_Test()
        {
            WeatherForecastOptions options = new();

            Assert.IsNotNull(options);
            Assert.IsTrue(options.Current_Weather);
            Assert.AreEqual(options.Latitude, 0f);
            Assert.AreEqual(options.Longitude, 0f);
            Assert.IsNotNull(options.Daily);
            Assert.IsNotNull(options.Hourly);
        }

        [TestMethod]
        public void  Latitude_Longitude_WeatherForecastOptions_Constructor_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(2.4f, 3.5f);

            Assert.IsNotNull(options);
            Assert.AreEqual(2.4f, options.Latitude);
            Assert.AreEqual(3.5f, options.Longitude);
            Assert.IsTrue(options.Current_Weather);
        }

        [TestMethod]
        public void Full_WeatherForecastOptions_Constructor_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(
                10.5f, 20.5f, "fahrenheit", "kmh", "mm", "auto", 
                new HourlyOptions(), new DailyOptions(), false, "iso8601", 1);

            Assert.IsFalse(options.Current_Weather);
            Assert.AreEqual(10.5f, options.Latitude);
            Assert.AreEqual(20.5f, options.Longitude);
            Assert.AreEqual("kmh", options.Windspeed_Unit);
            Assert.AreEqual("fahrenheit", options.Temperature_Unit);
            Assert.AreEqual("mm", options.Precipitation_Unit);
            Assert.AreEqual("iso8601", options.Timeformat);
            Assert.AreEqual("auto", options.Timezone);
            Assert.IsNotNull(options.Daily);
            Assert.IsNotNull(options.Hourly);
            Assert.AreEqual(1, options.Past_Days);
            

        }

        [TestMethod]
        public void WeatherForecastOptions_Daily_Hourly_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(
                10.5f, 20.5f, "kmh", "fahrenheit", "mm", "auto",
                new HourlyOptions(), new DailyOptions(), false, "iso8601", 1);

            Assert.IsTrue(options.Daily.Parameter.Count == 0);
            Assert.IsTrue(options.Hourly.Parameter.Count == 0);

            options.Daily.Add(DailyOptionsType.sunset);
            options.Daily.Add(DailyOptionsType.sunrise);

            Assert.IsTrue(options.Daily.Parameter.Count == 2);
            Assert.IsTrue(options.Daily.Parameter.Contains("sunrise"));
            Assert.IsTrue(options.Daily.Parameter.Contains("sunset"));

            options.Hourly.Add(HourlyOptionsParameter.cloudcover_low);
            options.Hourly.Add(HourlyOptionsParameter.cloudcover_high);

            Assert.IsTrue(options.Hourly.Parameter.Count == 2);
            Assert.IsTrue(options.Hourly.Parameter.Contains("cloudcover_low"));
            Assert.IsTrue(options.Hourly.Parameter.Contains("cloudcover_high"));
        }
    }
}
