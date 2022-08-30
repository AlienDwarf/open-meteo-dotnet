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
    public class LocationDataTests
    {
        [TestMethod]
        public async Task Get_Location_Data_With_String_Test()
        {
            OpenMeteoClient client = new();
            var res = await client.GetLocationDataAsync("Tokyo");

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Locations);

            Assert.AreEqual("japan", res.Locations[0].Country.ToLower());
        }

        [TestMethod]
        public async Task Get_Location_Data_With_Options_Test()
        {
            OpenMeteoClient client = new();
            var options = new GeocodingOptions("Tokyo");
            var res = await client.GetLocationDataAsync(options);

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Locations);
            Assert.AreEqual("japan", res.Locations[0].Country.ToLower());
        }

        [TestMethod]
        public async Task Get_Location_Latitude_Longitude_Test()
        {
            OpenMeteoClient client = new();
            var res = await client.GetLocationLatitudeLongitudeAsync("Tokyo");

            Assert.IsNotNull(res);
            Assert.IsTrue(res?.latitude > 0);
            Assert.IsTrue(res?.longitude > 0);
        }
    }
}
