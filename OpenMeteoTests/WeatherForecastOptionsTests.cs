using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;

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
            Assert.AreEqual(0, options.Daily.Parameter.Count);
            Assert.AreEqual(0, options.Hourly.Parameter.Count);
        }

        [TestMethod]
        public void Latitude_Longitude_WeatherForecastOptions_Constructor_Test()
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
                10.5f, 20.5f, TemperatureUnitType.fahrenheit, WindspeedUnitType.kmh, PrecipitationUnitType.mm, "auto",
                new HourlyOptions(), new DailyOptions(), false, TimeformatType.iso8601, 1, "", "");

            Assert.IsFalse(options.Current_Weather);
            Assert.AreEqual(10.5f, options.Latitude);
            Assert.AreEqual(20.5f, options.Longitude);
            Assert.AreEqual("kmh", options.Windspeed_Unit.ToString());
            Assert.AreEqual("fahrenheit", options.Temperature_Unit.ToString());
            Assert.AreEqual("mm", options.Precipitation_Unit.ToString());
            Assert.AreEqual("iso8601", options.Timeformat.ToString());
            Assert.AreEqual("auto", options.Timezone.ToString());
            Assert.IsNotNull(options.Daily);
            Assert.IsNotNull(options.Hourly);
            Assert.AreEqual(1, options.Past_Days);
            Assert.AreEqual(string.Empty, options.Start_date);
            Assert.AreEqual(string.Empty, options.End_date);

        }

        [TestMethod]
        public void WeatherForecastOptions_Daily_Hourly_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(
                10.5f, 20.5f, TemperatureUnitType.fahrenheit, WindspeedUnitType.kmh, PrecipitationUnitType.mm, "auto",
                new HourlyOptions(), new DailyOptions(), false, TimeformatType.iso8601, 1, "", "");

            options.Daily.Add(DailyOptionsParameter.sunset);
            options.Daily.Add(DailyOptionsParameter.sunrise);

            options.Hourly.Add(HourlyOptionsParameter.cloudcover_low);
            options.Hourly.Add(HourlyOptionsParameter.cloudcover_high);

            Assert.IsTrue(options.Hourly.Parameter.Count == 2);
            Assert.IsTrue(options.Hourly.Parameter.Contains(HourlyOptionsParameter.cloudcover_low));
            Assert.IsTrue(options.Hourly.Parameter.Contains(HourlyOptionsParameter.cloudcover_high));

            Assert.IsTrue(options.Daily.Parameter.Count == 2);
            Assert.IsTrue(options.Daily.Parameter.Contains(DailyOptionsParameter.sunrise));
            Assert.IsTrue(options.Daily.Parameter.Contains(DailyOptionsParameter.sunset));
        }
    }
}
