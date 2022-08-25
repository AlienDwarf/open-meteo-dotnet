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
    public class HourlyOptionsTests
    {
        [TestMethod]
        public void Daily_All_Hourly_All_Test()
        {
            var options = new WeatherForecastOptions(10.5f, 20f);
            options.Daily = DailyOptions.All;
            options.Hourly = HourlyOptions.All;

            Assert.IsTrue(options.Daily.Parameter.Count > 0);
            Assert.IsTrue(options.Hourly.Parameter.Count > 0);

            foreach (string s in DailyOptions.All.Parameter)
            {
                Assert.IsTrue(options.Daily.Parameter.Contains(s));
            }

            foreach (string s in HourlyOptions.All.Parameter)
            {
                Assert.IsTrue(options.Hourly.Parameter.Contains(s));
            }
        }
    }
}
