using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.Models
{
    public class Dungeon
    {
        [PrimaryKey, AutoIncrement]
        public int id {  get; set; }
        public string name { get; set; }
        public string level { get; set; }
        public int enchant { get; set; }
        public string zone { get; set; }
        public string type { get; set; }

    }
}
