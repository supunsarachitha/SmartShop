using SmartShop.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Data
{
    public class ShopDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ShopDatabase()
        {
           InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemList).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemList)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(StockBalance)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        internal Task<List<ItemStock>> GetStockItemsAsync()
        {

            return Database.QueryAsync<ItemStock>("SELECT I.ItemId,I.ItemName,I.ItemDescription,S.Qty FROM ItemList I left join StockBalance S ON S.ItemId=I.ItemId");
        }

        internal Task insertStock(StockBalance list)
        {
            StockBalance st = new StockBalance()
            {
                ItemId = list.ItemId,
                Qty = list.Qty,
            };
            return Database.InsertAsync(st);
        }

        internal Task<StockBalance> GetStockById(int itemId)
        {
            return Database.Table<StockBalance>().Where(i => i.ItemId == itemId).FirstOrDefaultAsync();

        }

        internal Task UpdateItemStock(StockBalance item)
        {
            return Database.UpdateAsync(item);
        }

        public Task<List<ItemList>> GetItemsAsync()
        {
            return Database.Table<ItemList>().ToListAsync();
        }

        public Task<List<ItemList>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<ItemList>("SELECT * FROM [ItemList]");
        }

        public Task<ItemList> GetItemAsync(int id)
        {
            return Database.Table<ItemList>().Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ItemList item)
        {
            if (item.ItemId != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ItemList item)
        {
            return Database.DeleteAsync(item);
        }



    }
}
