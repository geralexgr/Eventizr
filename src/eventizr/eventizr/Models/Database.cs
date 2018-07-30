using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eventizr.Models
{
    public class Database
    {
        //private readonly SQLiteAsyncConnection _connection;

        SQLiteAsyncConnection _connection;

        public Database()
        {
            _connection = DependencyService.Get<eventizr.Interfaces.ISQLite>().GetConnection();
            _connection.CreateTableAsync<Models.SqlitePage>();
        }

        public async Task<SqlitePage> CreatePageAsync(SqlitePage page)
        {
            var count = await _connection.InsertAsync(page);
            return (count == 1) ? page : null;
        }

        public async Task<ObservableCollection<SqlitePage>> GetAllPagesAsync()
        {
            try
            {
                var entities = await _connection.Table<SqlitePage>().OrderBy(x => x.Name).ToListAsync();
                return new ObservableCollection<SqlitePage>(entities);
            }
            catch (Exception)
            {
                return new ObservableCollection<SqlitePage>();
            }
        }



        public Task<SqlitePage> GetPageAsync(string id)
        {
            return _connection.Table<SqlitePage>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetPagesIds()
        {
            var count = _connection.Table<SqlitePage>().CountAsync().Result;
            if (count > 0)
            {
                List<SqlitePage> entities = new List<SqlitePage>();
                entities = await _connection.Table<SqlitePage>().OrderBy(x => x.Name).ToListAsync();
                List<string> list = new List<string>();
                for (int i = 0; i < entities.Count; i++)
                {
                    list.Add(entities[i].Id);
                }
                return list;
            }
            else
            {
                return new List<string>();
            }
            
            
        }

        public bool CheckPageExists(string id)
        {
            try
            {


                var count = _connection.Table<SqlitePage>().Where(x => x.Id == id).CountAsync().Result;
                if (count > 0)
                {
                    Task<SqlitePage> item = _connection.Table<SqlitePage>().Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (item.Result.Id != null) return true;
                    else return false;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception) { return false; }
          
        }

        public async Task<SqlitePage> DeletePageAsync(SqlitePage page)
        {
            var count = await _connection.DeleteAsync(page);
            return (count == 1) ? page : null;
        }

    }
}
