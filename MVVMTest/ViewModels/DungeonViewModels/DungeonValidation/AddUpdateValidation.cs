using MVVMTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.ViewModels.DungeonViewModels.DungeonValidation
{
    public class AddUpdateValidation
    {

        public bool CheckDungeonModel(Dungeon dungeon)
        {
            if(string.IsNullOrEmpty(dungeon.name) || 
                string.IsNullOrEmpty(dungeon.enchant.ToString()) ||
                string.IsNullOrEmpty(dungeon.level.ToString()) ||
                string.IsNullOrEmpty(dungeon.zone) ||
                string.IsNullOrEmpty(dungeon.type))
            {
                return false;
            }
            else if((dungeon.enchant>-1 && dungeon.enchant < 4))
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }
    }
}
