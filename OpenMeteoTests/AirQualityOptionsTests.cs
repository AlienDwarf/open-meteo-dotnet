using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMeteoTests
{
    [TestClass]
    public class AirQualityOptionsTests
    {
        [TestMethod]
        public void Empty_Object_Test()
        {
            AirQualityOptions options = new AirQualityOptions();

            Assert.AreEqual(0, options.Hourly.Count);
            Assert.AreEqual(0, options.Latitude);
            Assert.AreEqual(0, options.Longitude);
            Assert.AreEqual("auto", options.Domains);
            Assert.AreEqual("iso8601", options.Timeformat);
            Assert.AreEqual("GMT", options.Timezone);
            Assert.AreEqual(0, options.Past_Days);
            Assert.AreEqual("", options.Start_date);
            Assert.AreEqual("", options.End_date);
        }

        [TestMethod]
        public void All_Hourly_Object_Test()
        {
            AirQualityOptions options = new AirQualityOptions();
            options.Hourly = AirQualityOptions.HourlyOptions.All;

            Assert.AreEqual(Enum.GetValues(typeof(AirQualityOptions.HourlyOptionsParameter)).Length, options.Hourly.Count); ;

            foreach (var option in (AirQualityOptions.HourlyOptionsParameter[])Enum.GetValues(typeof(AirQualityOptions.HourlyOptionsParameter)))
            {
                Assert.IsTrue(options.Hourly.Contains(option));
            }
        }
    }
}
