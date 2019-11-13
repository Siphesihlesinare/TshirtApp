using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TshirtsApp.models;

namespace TshirtApp
{
    public class TshirtDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TshirtDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ShirtItem>().Wait();
        }

        public Task<List<ShirtItem>> GetItemsAsync()
        {
            return database.Table<ShirtItem>().ToListAsync();
        }

        public Task<List<ShirtItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ShirtItem>("SELECT * FROM [ShirtItem] WHERE [Done] = 0");
        }

        public Task<ShirtItem> GetItemAsync(int id)
        {
            return database.Table<ShirtItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ShirtItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ShirtItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}

