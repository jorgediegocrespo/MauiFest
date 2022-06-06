using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace MauiFest.Mappers;

public class ButtonMappers
{
    public static void CreateHandlers()
    {
        //Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Border", (handler, view) =>
        //{
        //    var gradientBackground = new GradientDrawable();
        //    gradientBackground.SetShape(ShapeType.Rectangle);
        //    gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        //    gradientBackground.SetStroke(2, Colors.Red.ToAndroid());
        //    gradientBackground.SetCornerRadius(DpToPixels(handler.PlatformView.Context, Convert.ToSingle(10)));
        //    handler.PlatformView.Background = gradientBackground;

        //    handler.PlatformView.SetPadding(
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingTop,
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingBottom);
        //});

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry.TextColor), (handler, view) =>
        //{
        //    var gradientBackground = new GradientDrawable();
        //    gradientBackground.SetShape(ShapeType.Rectangle);
        //    gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        //    gradientBackground.SetStroke(2, handler.PlatformView.TextColors); //view.TextColor.ToAndroid()
        //    gradientBackground.SetCornerRadius(DpToPixels(handler.PlatformView.Context, Convert.ToSingle(10)));
        //    handler.PlatformView.Background = gradientBackground;

        //    handler.PlatformView.SetPadding(
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingTop,
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingBottom);
        //});

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        //{
        //    var gradientBackground = new GradientDrawable();
        //    gradientBackground.SetShape(ShapeType.Rectangle);
        //    gradientBackground.SetColor(Colors.LightGray.ToAndroid());
        //    gradientBackground.SetStroke(2, handler.PlatformView.TextColors); //view.TextColor.ToAndroid()
        //    gradientBackground.SetCornerRadius(DpToPixels(handler.PlatformView.Context, Convert.ToSingle(10)));
        //    handler.PlatformView.Background = gradientBackground;

        //    handler.PlatformView.SetPadding(
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingTop,
        //            (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingBottom);
        //});

        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(Entry.TextColor), (handler, view, action) =>
        {
            var gradientBackground = new GradientDrawable();
            gradientBackground.SetShape(ShapeType.Rectangle);
            gradientBackground.SetColor(Colors.LightGray.ToAndroid());
            gradientBackground.SetStroke(2, view.TextColor.ToAndroid());
            gradientBackground.SetCornerRadius(DpToPixels(handler.PlatformView.Context, Convert.ToSingle(10)));
            handler.PlatformView.Background = gradientBackground;

            handler.PlatformView.SetPadding(
                    (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingTop,
                    (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingBottom);

            //action?.Invoke(handler, view);
        });
    }

    public static float DpToPixels(Context context, float valueInDp)
    {
        DisplayMetrics metrics = context.Resources.DisplayMetrics;
        return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
    }
}
