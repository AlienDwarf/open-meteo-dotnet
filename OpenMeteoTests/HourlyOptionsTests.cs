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
        public void HourlyOptions_Add_One_Parameter_Test()
        {
            var options = new HourlyOptions();

            Assert.AreEqual(0, options.Parameter.Count);
            options.Add(HourlyOptionsParameter.winddirection_80m);
            Assert.AreEqual(1, options.Parameter.Count);
            Assert.IsTrue(options.Parameter.Contains("winddirection_80m"));
            Assert.IsFalse(options.Add(HourlyOptionsParameter.winddirection_80m));
        }

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

        [TestMethod]
        public void HourlyOptions_Add_Already_Added_Test()
        {
            var hourly = HourlyOptions.All;

            Assert.IsFalse(hourly.Add(HourlyOptionsParameter.temperature_2m));
            Assert.IsFalse(hourly.Add(HourlyOptionsParameter.relativehumidity_2m));
            Assert.IsFalse(hourly.Add(HourlyOptionsParameter.dewpoint_2m));
            Assert.IsFalse(hourly.Add(HourlyOptionsParameter.apparent_temperature));
            Assert.IsFalse(hourly.Add(HourlyOptionsParameter.pressure_msl));
        }

        [TestMethod]
        public void HourlyOptions_ArgumentException_Test()
        {
            static void action() => new HourlyOptions("A not existing parameter");
            Assert.ThrowsException<ArgumentException>(action);

            static void action_array() => new HourlyOptions(new string[] { 
                "A", "not", "existing", "Array", "of", "parameter"
            });
            Assert.ThrowsException<ArgumentException>(action_array);
        }
    }
}
