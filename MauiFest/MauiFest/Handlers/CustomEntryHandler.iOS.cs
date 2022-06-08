//TODO 5.3 Handlers - own handler
using Microsoft.Maui.Platform;

namespace MauiFest.Handlers;

public partial class CustomEntryHandler
{
    protected override MauiTextField CreatePlatformView()
    {
        var mauiTextField = base.CreatePlatformView();
        mauiTextField.Layer.CornerRadius = Convert.ToSingle(10);
        mauiTextField.Layer.BorderColor = Colors.Blue.ToCGColor();
        mauiTextField.Layer.BorderWidth = 2;
        mauiTextField.ClipsToBounds = true;

        return mauiTextField;
    }
}
