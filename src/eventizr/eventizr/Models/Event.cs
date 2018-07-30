using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eventizr.Models
{
    public class Event
    {

        public List<FbData> Data { get; set; }

        public class FbData
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("start_time")]
            public DateTime Time { get; set; }       

            [JsonProperty("cover")]
            public Picture Cover { get; set; }

            [JsonProperty("owner")]
            public Owner Host { get; set; }

            [JsonProperty("place")]
            public Place Location { get; set; }

            [JsonProperty("cursors")]
            public Cursor Paging { get; set; }

        }
      
        public class Owner
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }
      
        public class Picture
        {
            [JsonProperty("offset_x")]
            public int OffsetX { get; set; }

            [JsonProperty("offset_y")]
            public int OffsetY { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }


        }

        public class Place
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("location")]
            public Spot Info { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

        }

        public class Spot
        {
            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("latitude")]
            public Double Latitude { get; set; }

            [JsonProperty("longitude")]
            public Double Longitude { get; set; }

            [JsonProperty("street")]
            public string Street { get; set; }

            [JsonProperty("zip")]
            public string Zip { get; set; }
        }


        public class Cursor
        {
            public string Before { get; set; }
            public string After { get; set; }

        }

    }
}
