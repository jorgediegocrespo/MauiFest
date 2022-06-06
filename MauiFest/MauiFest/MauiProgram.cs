//TODO 2
//#if ANDROID
//using MauiFest.Platforms.Android.Services;
//#elif IOS
//using MauiFest.Platforms.iOS.Services;
//#endif


using MauiFest.Services;
using MauiFest.Features;
using MauiFest.Mappers;

namespace MauiFest;

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

		builder.Services
            //TODO 2
			.AddSingleton<ISettingsService, SettingsService>()
            .AddTransient<AppShell>()
            .AddTransient<MainPage>()
            .AddTransient<MainViewModel>();

        CreateHandlers();
        return builder.Build();
	}

    private static void CreateHandlers()
    {
        ButtonMappers.CreateHandlers();
    }
}
