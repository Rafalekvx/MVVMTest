using Microsoft.Extensions.Logging;
using MVVMTest.Services;
using MVVMTest.ViewModels.DungeonViewModels;
using MVVMTest.Views;

namespace MVVMTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif




		//viewmodels
		builder.Services.AddSingleton<DungeonDisplayViewModel>();
		builder.Services.AddTransient<AddDungeonPageViewModel>();
		builder.Services.AddTransient<UpdateDungeonPageViewModel>();


        //views
        builder.Services.AddSingleton<DungeonDisplay>();
        builder.Services.AddTransient<AddDungeonPage>();
        builder.Services.AddTransient<UpdateDungeonPage>();


        return builder.Build();
	}
}
