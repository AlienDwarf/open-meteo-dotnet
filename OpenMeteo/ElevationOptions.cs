namespace OpenMeteo
{
    internal class ElevationOptions
    {
        public ElevationOptions(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Longitude { get; set; }
    }
}
