using MVVMTest.Services;

namespace MVVMTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DependencyService.Register<DungeonService>();

		MainPage = new AppShell();
	}
}
