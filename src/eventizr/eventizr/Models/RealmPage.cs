using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace eventizr.Models
{
    public class RealmPage : RealmObject
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
    }
}
