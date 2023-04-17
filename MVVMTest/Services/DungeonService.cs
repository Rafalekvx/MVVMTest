using MVVMTest.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Services
{
    public class DungeonService : IDungeonService<Dungeon>
    {
       
        SQLiteAsyncConnection _connection {get;set;}
        


        public DungeonService()
        {
            Init();
        }

        public void Init()
        {
            if(_connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dungeon.db3");
                _connection = new SQLiteAsyncConnection(dbPath);
                _connection.CreateTableAsync<Dungeon>();
            }
        }



        List<Dungeon> dungeons;


        public Task<List<Dungeon>> GetAllAsync()
        {
            ObservableCollection<Dungeon> dungeons = new ObservableCollection<Dungeon>();

            var listResponse = _connection.Table<Dungeon>().ToListAsync();

            return listResponse;

        }


        public Task<int> AddItemAsync(Dungeon dungeon)
        {
            return _connection.InsertAsync(dungeon);
        }

        public Task<int> RemoveItemAsync(Dungeon dungeon)
        {
            return _connection.DeleteAsync(dungeon);
        }

        public Task<int> UpdateItemAsync(Dungeon dungeon)
        {
            return _connection.UpdateAsync(dungeon);
        }

        public Dungeon GetItemAsync(int id)
        {
            var HelperList = _connection.Table<Dungeon>().Where(x => x.id == id).ToListAsync().Result;
            return HelperList[0];
        }
    }
}
