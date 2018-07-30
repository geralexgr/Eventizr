using eventizr.Interfaces;
using eventizr.UWP.Helpers;
using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]
namespace eventizr.UWP.Helpers
{
    public class SqliteService: ISQLite
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "database.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            var conn = new SQLite.SQLiteAsyncConnection(path);
            return conn;
        }

    }
}
