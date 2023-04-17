using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTest.Models;
using MVVMTest.Services;
using MVVMTest.ViewModels.DungeonViewModels.DungeonValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.ViewModels.DungeonViewModels
{
    public partial class AddDungeonPageViewModel : ObservableObject
    {
        public IDungeonService<Dungeon> _service => DependencyService.Get<IDungeonService<Dungeon>>();

        AddUpdateValidation _validation = new AddUpdateValidation();

        public List<DungeonTier> TierList { get; set; }

        public List<DungeonEnchant> EnchantList { get; set; }


        public AddDungeonPageViewModel()
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




        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private DungeonTier _level;


        public DungeonTier SelectedTier
        {
            get { return Level; }
            set { Level = value;
                OnPropertyChanged();
            }
        }


        [ObservableProperty]
        private DungeonEnchant _enchant;

        public DungeonEnchant SelectedEnchant
        {
            get { return Enchant; }
            set
            {
                Enchant = value;
                OnPropertyChanged();
            }
        }


        [ObservableProperty]
        private string _zone;
        [ObservableProperty]
        private string _type;



        [RelayCommand]
        public async void AddNewDungeon()
        {
            Dungeon tempDungeon = new Dungeon
            {
                name = Name,
                level = Level.Tier,
                enchant = Enchant.Enchant,
                zone = Zone,
                type = Type
            };

            bool check = _validation.CheckDungeonModel(tempDungeon);

            if (check)
            {
                var response = await _service.AddItemAsync(tempDungeon);
                if (response > 0)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Something wrong", "Dungeon is not added", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Something wrong", "Dungeon is not added", "OK");
            }
        }

    }
}
