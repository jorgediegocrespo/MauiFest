//TODO 3.2
using Foundation;
using UIKit;

namespace MauiFest.Services;

public class SettingsService : ISettingsService
{
    public void OpenAppSettings()
    {
        var url = new NSUrl("app-settings:com.companyname.mauifest");
        UIApplication.SharedApplication.OpenUrl(url);
    }
}
