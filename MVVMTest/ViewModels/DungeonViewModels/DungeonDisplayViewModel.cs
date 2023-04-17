using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MVVMTest.Models;
using MVVMTest.Services;
using MVVMTest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTest.ViewModels.DungeonViewModels
{
    public partial class DungeonDisplayViewModel : ObservableObject
    {
        public ObservableCollection<Dungeon> dungeonsCollection { get; set; } = new ObservableCollection<Dungeon>();

        public IDungeonService<Dungeon> _service => DependencyService.Get<IDungeonService<Dungeon>>();

        public Dungeon selectedDungeon { get; set; } = new Dungeon();

        public string ItemId { get; set; }

        public Command ItemTapped { get;}


        public DungeonDisplayViewModel() 
        {
            ItemTapped = new Command(UpdateDungeon);
        }

        

        [RelayCommand]
        public async void GetDungeonList()
        {
            var dungeonList = await _service.GetAllAsync();

            if (dungeonList?.Count > 0 )
            {
                dungeonsCollection.Clear();

                foreach( var dungeon in dungeonList )
                {
                    dungeonsCollection.Add(dungeon);
                }
            }
        }



        [RelayCommand]
        public async void AddDungeon()
        {
            await AppShell.Current.GoToAsync(nameof(AddDungeonPage));
        }

        [RelayCommand]
        public async void UpdateDungeon()
        {
            ItemId = selectedDungeon.id.ToString();
            await Shell.Current.GoToAsync($"{nameof(UpdateDungeonPage)}?{nameof(UpdateDungeonPageViewModel.ItemId)} = {ItemId}");
        }

    }
}
