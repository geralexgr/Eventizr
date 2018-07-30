using System;
using System.Collections.Generic;
using System.Text;

namespace eventizr.Models
{
    public class SqliteEvent
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public string Picture { get; set; }

        public string Host { get; set; }

        public string Address { get; set; }


        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
    }
}
