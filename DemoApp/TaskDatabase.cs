using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class TaskDatabase
    {
        readonly SQLiteAsyncConnection _database;

        private TaskDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public static async Task<TaskDatabase> CreateAsync(string dbPath)
        {
            var database = new TaskDatabase(dbPath);
            await database._database.CreateTableAsync<TaskItem>();
            return database;
        }

        public Task<List<TaskItem>> GetItemsAsync()
        {
            return _database.Table<TaskItem>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(TaskItem item)
        {
            try
            {
                if (item.ID != 0)
                {
                    return await _database.UpdateAsync(item);
                }
                else
                {
                    return await _database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Debug.WriteLine($"Error in SaveItemAsync: {ex.Message}");
                return 0;
            }
        }

        public Task<int> DeleteItemAsync(TaskItem item)
        {
            return _database.DeleteAsync(item);
        }

        public async Task<TaskItem> GetItemByTextAsync(string text)
        {
            return await _database.Table<TaskItem>().Where(i => i.Text == text).FirstOrDefaultAsync();
        }

        // Method to load all items from the database
        public async Task<List<TaskItem>> LoadAllItemsAsync()
        {
            return await _database.Table<TaskItem>().ToListAsync();
        }



    }
}
