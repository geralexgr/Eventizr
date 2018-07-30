using SQLite;
using System;

namespace eventizr.Models
{
    public class SqlitePage
    {
        [PrimaryKey, AutoIncrement]
        public int SQLiteId { get; set; }
		public string Id { get; set; }
		public string Url { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string Address { get; set; }
		public string Picture { get; set; }
    }
}
