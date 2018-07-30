using System;
using eventizr.Interfaces;
using System.IO;
using Xamarin.Forms;
using eventizr.iOS;
using SQLite;
using eventizr.iOS.Helpers;

[assembly: Dependency(typeof(SqliteService))]
namespace eventizr.iOS.Helpers
{
    public class SqliteService: ISQLite
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "database.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }
    }
}
