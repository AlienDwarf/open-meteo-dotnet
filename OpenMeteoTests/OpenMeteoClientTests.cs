using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;

namespace OpenMeteoTests
{
    [TestClass]
    public class OpenMeteoClientTests
    {
        [TestMethod]
        public void Weather_Codes_To_String_Tests()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            int[] testWeatherCodes = { 0, 1, 2, 3, 51, 53, 96, 99, 100 };
            foreach (var weatherCode in testWeatherCodes)
            {
                string weatherCodeString = client.WeathercodeToString(weatherCode);
                Assert.IsInstanceOfType(weatherCodeString, typeof(string));

                if (weatherCode == 0)
                    Assert.AreEqual("Clear sky", weatherCodeString);

                if (weatherCode == 100)
                    Assert.AreEqual("Invalid weathercode", weatherCodeString);
            }
        }
    }
}