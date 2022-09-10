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
    public class AirQualityTests
    {
        [TestMethod]
        public async Task Air_Quality_Test()
        {
            OpenMeteoClient client = new();
            AirQualityOptions options = new()
            {
                Hourly = AirQualityOptions.HourlyOptions.All,
                Latitude = 52.5235f,
                Longitude = 13.4115f
            };

            AirQuality res = await client.QueryAsync(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res?.Hourly);
            Assert.IsNotNull(res?.Hourly_Units);
        }

        [TestMethod]
        public void Air_Quality_Sync_Test()
        {
            OpenMeteoClient client = new();
            AirQualityOptions options = new()
            {
                Hourly = AirQualityOptions.HourlyOptions.All,
                Latitude = 52.5235f,
                Longitude = 13.4115f
            };
            var res = client.Query(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res?.Hourly);
            Assert.IsNotNull(res?.Hourly_Units);
            Assert.IsTrue(res.GenerationTime > 0);
        }
    }
}
