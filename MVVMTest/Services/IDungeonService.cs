using MVVMTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Services
{
    public interface IDungeonService<T>
    {
        Task<List<Dungeon>> GetAllAsync();
        Task<int> UpdateItemAsync(Dungeon dungeon);
        Task<int> AddItemAsync(Dungeon dungeon);
        Task<int> RemoveItemAsync(Dungeon dungeon);
        Dungeon GetItemAsync(int id);

    }
}
