using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Models;
using MVVMTest.Services;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVVMTest.ViewModels.DungeonViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class UpdateDungeonPageViewModel : ObservableObject
    {
        private Dungeon DungeonDetails = new Dungeon();

        public IDungeonService<Dungeon> _service => DependencyService.Get<IDungeonService<Dungeon>>();

        private string itemId;

        public string ItemId
        {
            get 
            {
                return itemId;
            }
            set 
            {
                itemId = value;
                LoadItemId(value);    
            }
        
        }


        public List<DungeonTier> TierList { get; set; }

        public List<DungeonEnchant> EnchantList { get; set; }

        public UpdateDungeonPageViewModel()
        {

            TierList = new List<DungeonTier>();
            TierList.Add(new DungeonTier() { Id = 0, Tier = "4" });
            TierList.Add(new DungeonTier() { Id = 1, Tier = "5" });
            TierList.Add(new DungeonTier() { Id = 2, Tier = "6" });
            TierList.Add(new DungeonTier() { Id = 3, Tier = "7" });
            TierList.Add(new DungeonTier() { Id = 4, Tier = "8" });

            EnchantList = new List<DungeonEnchant>();
            EnchantList.Add(new DungeonEnchant() { Id = 0, Enchant = 0 });
            EnchantList.Add(new DungeonEnchant() { Id = 1, Enchant = 1 });
            EnchantList.Add(new DungeonEnchant() { Id = 2, Enchant = 2 });
            EnchantList.Add(new DungeonEnchant() { Id = 3, Enchant = 3 });

            
        }

        public event PropertyChangingEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        private string name;

        public string Name
        {
            get => name; 
            set => name = value;
        }

        private string zone;

        public string Zone
        {
            get => zone; 
            set => zone = value;
        }

        private string type;
        public string Type
        {
            get => type; 
            set => type = value;
        }

        private DungeonTier level;

        public DungeonTier Level
        {
            get => level;
            set => level = value;
        }




        public DungeonTier SelectedTier
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }

        private DungeonEnchant enchant;

        public DungeonEnchant Enchant
        {
            get => enchant;
            set => enchant = value;
        }

        public DungeonEnchant SelectedEnchant
        {
            get { return enchant; }
            set
            {
                enchant = value;
                OnPropertyChanged();
            }
        }

        public void LoadItemId(string itemId)
        {
            try
            {
                var item = _service.GetItemAsync(int.Parse(itemId));
                Name = item.name;
                Type = item.type;
                Zone = item.zone;
                Enchant.Enchant = item.enchant;
                Level.Tier = item.level;
            }
            catch (Exception ex)
            {
                 Debug.WriteLine(ex);
            }
        }



        [RelayCommand]
        public async void UpdateDungeon()
        {
            DungeonDetails.enchant = Enchant.Enchant;

            DungeonDetails.level = Level.Tier;


            int respone = -1;
            if (DungeonDetails.id > 0)
            {
                respone = await _service.UpdateItemAsync(DungeonDetails);
            }
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        public async void DeleteDungeon()
        {
            var delResponse = await _service.RemoveItemAsync(DungeonDetails);
            if(delResponse > 0)
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }


    }

}
