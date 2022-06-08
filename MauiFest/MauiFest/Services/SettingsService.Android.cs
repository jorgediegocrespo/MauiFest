//TODO 3.1 Common services
using Android.Content;

namespace MauiFest.Services;

public class SettingsService : ISettingsService
{
    public void OpenAppSettings()
    {
        var context = global::Android.App.Application.Context;

        var intent = new Intent(global::Android.Provider.Settings.ActionApplicationDetailsSettings);
        intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.NoHistory | ActivityFlags.ExcludeFromRecents);
        var uri = global::Android.Net.Uri.Parse("package:com.companyname.mauifest");
        intent.SetData(uri);
        context.StartActivity(intent);
    }
}
