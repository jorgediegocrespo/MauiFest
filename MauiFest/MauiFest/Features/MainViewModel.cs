using MauiFest.Services;
using System.Windows.Input;
using TaskManager.Base;

//TODO 1.3 Preprocessor directives
#if ANDROID
using Android.Content;
#elif IOS
using Foundation;
using UIKit;
#endif

namespace MauiFest.Features;

public class MainViewModel : BaseViewModel
{
    //TODO 1.1 Preprocessor directives
    public MainViewModel()
    {
        OpenAppSettingsCommand = new Command(OpenAppSetting);
    }

    //TODO 2.4 Platform services
    //private readonly ISettingsService settingsService;
    //public MainViewModel(ISettingsService settingsService)
    //{
    //    this.settingsService = settingsService;
    //    OpenAppSettingsCommand = new Command(settingsService.OpenAppSettings);
    //}

    public ICommand OpenAppSettingsCommand { get; private set; }

    //TODO 1.2 Preprocessor directives
    private void OpenAppSetting(object obj)
    {
#if ANDROID
        var context = global::Android.App.Application.Context;

        var intent = new Intent(global::Android.Provider.Settings.ActionApplicationDetailsSettings);
        intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.NoHistory | ActivityFlags.ExcludeFromRecents);
        var uri = global::Android.Net.Uri.Parse("package:com.companyname.mauifest");
        intent.SetData(uri);
        context.StartActivity(intent);
#elif IOS
            var url = new NSUrl("app-settings:com.companyname.mauifest");
            UIApplication.SharedApplication.OpenUrl(url);
#endif
    }
}
