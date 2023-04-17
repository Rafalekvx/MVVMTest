using MVVMTest.Models;
using MVVMTest.ViewModels.DungeonViewModels;

namespace MVVMTest.Views;

public partial class DungeonDisplay : ContentPage
{
	protected DungeonDisplayViewModel _viewModel;

	public DungeonDisplay()
	{
		InitializeComponent();
        _viewModel = new DungeonDisplayViewModel();
		this.BindingContext = _viewModel;
	}



    public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        if (args.SelectedItem == null)
        {
            return;
        }

        _viewModel.selectedDungeon = args.SelectedItem as Dungeon;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetDungeonList();
    }
}