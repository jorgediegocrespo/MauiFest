//TODO 5.2 Handlers - own handler
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace MauiFest.Handlers;

public partial class CustomEntryHandler
{
    protected override AppCompatEditText CreatePlatformView()
    {
        var appCompatEditText = base.CreatePlatformView();

        var gradientBackground = new GradientDrawable();
        gradientBackground.SetShape(ShapeType.Rectangle);
        gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        gradientBackground.SetStroke(2, Colors.Blue.ToAndroid()); 
        gradientBackground.SetCornerRadius(DpToPixels(appCompatEditText.Context, Convert.ToSingle(10)));
        appCompatEditText.Background = gradientBackground;

        appCompatEditText.SetPadding(
                (int)DpToPixels(appCompatEditText.Context, Convert.ToSingle(12)), appCompatEditText.PaddingTop,
                (int)DpToPixels(appCompatEditText.Context, Convert.ToSingle(12)), appCompatEditText.PaddingBottom);

        return appCompatEditText;
    }

    private float DpToPixels(Context context, float valueInDp)
    {
        DisplayMetrics metrics = context.Resources.DisplayMetrics;
        return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
    }
}
