using System;
using eventizr.Interfaces;
using Xamarin.Forms;
using System.IO;
using eventizr.Droid.Helpers;
using eventizr.Droid;
using SQLite;

[assembly: Dependency(typeof(SqliteService))]
namespace eventizr.Droid.Helpers
{
    public class SqliteService : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "database.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }

    }
}

