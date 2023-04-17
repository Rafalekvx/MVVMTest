using MVVMTest.Views;

namespace MVVMTest;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddDungeonPage), typeof(AddDungeonPage));

        Routing.RegisterRoute(nameof(UpdateDungeonPage), typeof(UpdateDungeonPage));
    }
}
