using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;
using System.Threading.Tasks;

namespace OpenMeteoTests
{
    [TestClass]
    public class ElevationTests
    {
        private static readonly float Latitude = 52.5235f;
        private static readonly float Longitude = 13.4115f;

        [TestMethod]
        public async Task Elevation_Async_Test()
        {
            OpenMeteoClient client = new();
            var res = await client.QueryElevationAsync(Latitude, Longitude);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Elevation.Length, 1);
        }

        [TestMethod]
        public void Elevation_Sync_Test()
        {
            OpenMeteoClient client = new();
            var res = client.QueryElevation(Latitude, Longitude);

            Assert.IsNotNull(res);
            Assert.AreEqual(res.Elevation.Length, 1);
        }
    }
}
