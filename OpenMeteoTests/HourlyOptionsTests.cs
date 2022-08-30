using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;
using System;

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
            Assert.IsTrue(options.Parameter.Contains(HourlyOptionsParameter.winddirection_80m));
            
        }

        [TestMethod]
        public void HourlyOptions_Add_Existing_Parameter_Test()
        {
            var options = new HourlyOptions();

            options.Add(HourlyOptionsParameter.soil_moisture_3_9cm);
            options.Add(HourlyOptionsParameter.soil_moisture_3_9cm);

            Assert.AreEqual(1, options.Count);
        }

        [TestMethod]
        public void Daily_All_Hourly_All_Test()
        {
            var options = new WeatherForecastOptions(10.5f, 20f);
            options.Daily = DailyOptions.All;
            options.Hourly = HourlyOptions.All;

            Assert.IsTrue(options.Daily.Parameter.Count > 0);
            Assert.IsTrue(options.Hourly.Parameter.Count > 0);

            foreach(var dailyOption in (DailyOptionsParameter[])Enum.GetValues(typeof(DailyOptionsParameter)))
            {
                Assert.IsTrue(options.Daily.Contains(dailyOption));
            }

            foreach(var hourlyOption in (HourlyOptionsParameter[])Enum.GetValues(typeof(HourlyOptionsParameter)))
            {
                Assert.IsTrue(options.Hourly.Contains(hourlyOption));
            }
        }

        [TestMethod]
        public void HourlyOptions_Add_Already_Added_Test()
        {
            var hourly = HourlyOptions.All;
            int oldCount = hourly.Count;

            hourly.Add(HourlyOptionsParameter.cloudcover);
            
            Assert.AreEqual(oldCount, hourly.Count);
        }

        /*[TestMethod]
        public void HourlyOptions_ArgumentException_Test()
        {
            static void action() => new HourlyOptions("A not existing parameter");
            Assert.ThrowsException<ArgumentException>(action);

            static void action_array() => new HourlyOptions(new string[] { 
                "A", "not", "existing", "Array", "of", "parameter"
            });
            Assert.ThrowsException<ArgumentException>(action_array);
        }*/

        /*[TestMethod]
        public void HourlyOptionsParameter_String_To_Enum_Test()
        {
            string hourlyOptionsParameterString = HourlyOptions.All[0];
            HourlyOptions options = new HourlyOptions(hourlyOptionsParameterString);

            var toTest = options.HourlyOptionsStringToEnum(options[0]);

            Assert.AreEqual(hourlyOptionsParameterString, toTest?.ToString());
        }*/
    }
}
