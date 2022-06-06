//TODO 5.3
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;

namespace MauiFest.Effects;

public class NativeEntryBorderEffect : PlatformEffect
{
    protected override void OnAttached()
    {
        var platformView = Control as MauiTextField;
        var view = Element as IEntry;
        var aux = Container;

        platformView.Layer.CornerRadius = Convert.ToSingle(10);
        platformView.Layer.BorderColor = view.TextColor.ToCGColor();
        platformView.Layer.BorderWidth = 2;
        platformView.ClipsToBounds = true;
    }

    protected override void OnDetached()
    {
    }
}