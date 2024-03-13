namespace OpenMeteo
{
    /// <summary>
    /// Elevation API response
    /// </summary>
    public class ElevationApiResponse
    {
        /// <summary>
        /// Elevation array in meters - this library currently only supports 1 input elevation so this will always be a single value array
        public float[]? Elevation { get; set; }
    }
}
