using MauiFest.Services;
using MauiFest.Features;
using MauiFest.Mappers;
using MauiFest.Effects;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using MauiFest.Controls;
using MauiFest.Renderers;
using MauiFest.Handlers;

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
			})
            //TODO 7.4
            //.ConfigureEffects(effectsBuilder =>
            //{
                //effectsBuilder.Add<EntryBorderEffect, NativeEntryBorderEffect>();
            //})
            //TODO 8.4
            //.UseMauiCompatibility()
            //.ConfigureMauiHandlers((handlers) =>
            //{
            //    handlers.AddCompatibilityRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer));
            //})
            //TODO 5.4
            //.ConfigureMauiHandlers((handlers) =>
            //{
            //    handlers.AddHandler(typeof(Entry), typeof(CustomEntryHandler));
            //})
            .Services
                //TODO 2.5
                //#if ANDROID
                //.AddSingleton<ISettingsService, MauiFest.Platforms.Android.Services.SettingsService>()
                //#elif IOS    
                //.AddSingleton<ISettingsService, MauiFest.Platforms.iOS.Services.SettingsService>()
                //#endif
                .AddSingleton<ISettingsService, SettingsService>()
                .AddTransient<AppShell>()
                .AddTransient<MainPage>()
                .AddTransient<MainViewModel>();

        //TODO 4.3
        //CreateHandlers();
        return builder.Build();
	}

    private static void CreateHandlers()
    {
        ButtonMappers.CreateHandlers();
    }
}
