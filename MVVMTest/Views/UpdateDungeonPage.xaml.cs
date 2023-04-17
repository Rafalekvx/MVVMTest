using MVVMTest.ViewModels.DungeonViewModels;

namespace MVVMTest.Views;

public partial class UpdateDungeonPage : ContentPage
{
    protected UpdateDungeonPageViewModel _viewModel;
    public UpdateDungeonPage()
	{
		InitializeComponent();
		_viewModel = new UpdateDungeonPageViewModel();	
		this.BindingContext = _viewModel;

	}
}