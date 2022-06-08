//TODO 6.1 Handlers - lifecycle
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Diagnostics;

namespace MauiFest.Features;

public partial class MainPage
{
    private void entryTest2_HandlerChanging(object sender, HandlerChangingEventArgs e)
    {
        Debug.WriteLine($"***** Handler changing OldHandler {e.OldHandler}");
        Debug.WriteLine($"***** Handler changing NewHandler {e.NewHandler}");
    }

    private void entryTest2_HandlerChanged(object sender, EventArgs e)
    {
        Debug.WriteLine($"***** Handler changed");
        var appCompatEditText = (sender as Entry).Handler.PlatformView as AppCompatEditText;

        var gradientBackground = new GradientDrawable();
        gradientBackground.SetShape(ShapeType.Rectangle);
        gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        gradientBackground.SetStroke(2, Colors.Pink.ToAndroid());
        gradientBackground.SetCornerRadius(DpToPixels(appCompatEditText.Context, Convert.ToSingle(10)));
        appCompatEditText.Background = gradientBackground;

        appCompatEditText.SetPadding(
                (int)DpToPixels(appCompatEditText.Context, Convert.ToSingle(12)), appCompatEditText.PaddingTop,
                (int)DpToPixels(appCompatEditText.Context, Convert.ToSingle(12)), appCompatEditText.PaddingBottom);
    }

    private float DpToPixels(Context context, float valueInDp)
    {
        DisplayMetrics metrics = context.Resources.DisplayMetrics;
        return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
    }
}
