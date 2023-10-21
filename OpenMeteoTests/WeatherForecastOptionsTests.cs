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
            Assert.IsNotNull(options.Current);
            Assert.AreEqual(options.Latitude, 0f);
            Assert.AreEqual(options.Longitude, 0f);
            Assert.IsNotNull(options.Daily);
            Assert.IsNotNull(options.Hourly);
            Assert.IsNotNull(options.Current);
            Assert.IsNotNull(options.Minutely15);
            Assert.AreEqual(0, options.Daily.Parameter.Count);
            Assert.AreEqual(0, options.Hourly.Parameter.Count);
            Assert.AreEqual(0, options.Current.Parameter.Count);
            Assert.AreEqual(0, options.Minutely15.Parameter.Count);
        }

        [TestMethod]
        public void Latitude_Longitude_WeatherForecastOptions_Constructor_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(2.4f, 3.5f);

            Assert.IsNotNull(options);
            Assert.AreEqual(2.4f, options.Latitude);
            Assert.AreEqual(3.5f, options.Longitude);
            Assert.IsNotNull(options.Current);
        }

        [TestMethod]
        public void Full_WeatherForecastOptions_Constructor_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(
                10.5f, 20.5f, TemperatureUnitType.fahrenheit, WindspeedUnitType.kmh, PrecipitationUnitType.mm, "auto",
                new HourlyOptions(), new DailyOptions(), new CurrentOptions(), new Minutely15Options(), TimeformatType.iso8601, 1, "", "", new WeatherModelOptions(), CellSelectionType.land);

            Assert.AreEqual(10.5f, options.Latitude);
            Assert.AreEqual(20.5f, options.Longitude);
            Assert.AreEqual("kmh", options.Windspeed_Unit.ToString());
            Assert.AreEqual("fahrenheit", options.Temperature_Unit.ToString());
            Assert.AreEqual("mm", options.Precipitation_Unit.ToString());
            Assert.AreEqual("iso8601", options.Timeformat.ToString());
            Assert.AreEqual("auto", options.Timezone.ToString());
            Assert.IsNotNull(options.Daily);
            Assert.IsNotNull(options.Hourly);
            Assert.IsNotNull(options.Current);
            Assert.IsNotNull(options.Minutely15);
            Assert.AreEqual(1, options.Past_Days);
            Assert.AreEqual(string.Empty, options.Start_date);
            Assert.AreEqual(string.Empty, options.End_date);

        }

        [TestMethod]
        public void WeatherForecastOptions_Daily_Hourly_Test()
        {
            WeatherForecastOptions options = new WeatherForecastOptions(
                10.5f, 20.5f, TemperatureUnitType.fahrenheit, WindspeedUnitType.kmh, PrecipitationUnitType.mm, "auto",
                new HourlyOptions(), new DailyOptions(), new CurrentOptions(), new Minutely15Options(), TimeformatType.iso8601, 1, "", "", new WeatherModelOptions(), CellSelectionType.land);

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
