using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using SQLite;
using RiddleMe.Models;

namespace RiddleMe.Data
{
    public class RiddleItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>

        {

            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

        });



        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        static bool initialized = false;



        public RiddleItemDatabase()

        {

            InitializeAsync().SafeFireAndForget(false);

        }



        async Task InitializeAsync()

        {

            if (!initialized)

            {

                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(RiddleItem).Name))

                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(RiddleItem)).ConfigureAwait(false);

                    initialized = true;

                }

            }

        }



        public Task<List<RiddleItem>> GetItemsAsync()

        {

            return Database.Table<RiddleItem>().ToListAsync();

        }



        //public Task<List<RiddleItem>> GetItemsNotDoneAsync()

        //{

        //    return Database.QueryAsync<RiddleItem>("SELECT * FROM [RiddleItem] WHERE [Done] = 0");

        //}



        public Task<RiddleItem> GetItemAsync(int id)

        {

            return Database.Table<RiddleItem>().Where(i => i.ID == id).FirstOrDefaultAsync();

        }



        public Task<int> SaveItemAsync(RiddleItem item)

        {

            if (item.ID != 0)

            {

                return Database.UpdateAsync(item);

            }

            else

            {

                return Database.InsertAsync(item);

            }

        }



        public Task<int> DeleteItemAsync(RiddleItem item)

        {

            return Database.DeleteAsync(item);

        }

    }

}
