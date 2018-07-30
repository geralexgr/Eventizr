using System;
using SQLite;


namespace eventizr.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
