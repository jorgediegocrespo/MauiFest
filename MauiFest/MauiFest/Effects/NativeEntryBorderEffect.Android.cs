//TODO 7.2 Effects
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace MauiFest.Effects;

public class NativeEntryBorderEffect : PlatformEffect
{
    protected override void OnAttached()
    {
        var platformView = Control as AppCompatEditText;
        var view = Element as IEntry;
        var aux = Container;

        var gradientBackground = new GradientDrawable();
        gradientBackground.SetShape(ShapeType.Rectangle);
        gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        gradientBackground.SetStroke(2, Colors.Green.ToAndroid());
        gradientBackground.SetCornerRadius(DpToPixels(platformView.Context, Convert.ToSingle(10)));
        platformView.Background = gradientBackground;

        platformView.SetPadding(
                (int)DpToPixels(platformView.Context, Convert.ToSingle(12)), platformView.PaddingTop,
                (int)DpToPixels(platformView.Context, Convert.ToSingle(12)), platformView.PaddingBottom);
    }

    protected override void OnDetached()
    {
    }

    private float DpToPixels(Context context, float valueInDp)
    {
        DisplayMetrics metrics = context.Resources.DisplayMetrics;
        return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
    }
}
