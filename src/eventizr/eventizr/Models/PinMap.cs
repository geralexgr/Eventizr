using System;

namespace eventizr.Models
{
    public class PinMap
    {
		public Double Latitude { get; set; }
		public Double Longitude { get; set; }

        public PinMap(Double lat,Double lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }
}
