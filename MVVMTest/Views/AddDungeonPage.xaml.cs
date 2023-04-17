using MVVMTest.Models;
using MVVMTest.ViewModels.DungeonViewModels;

namespace MVVMTest.Views;

public partial class AddDungeonPage : ContentPage
{
    protected AddDungeonPageViewModel _viewModel;
    public AddDungeonPage()
	{
		InitializeComponent();
		_viewModel = new AddDungeonPageViewModel();
		this.BindingContext = _viewModel;
		LevelPicker.SelectedIndex = 0;
		EnchantPicker.SelectedIndex = 0;
	}
}