using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Diagnostics;

namespace MauiFest.Mappers;

public class ButtonMappers
{
    //TODO 4.1 Handlers - mappers
    public static void CreateMappers()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** ModifyMapping MauiFestMap 1");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** ModifyMapping MauiFestMap 2");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** PrependToMapping MauiFestMap");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping("MauiFestMap", (handler, view, action) =>
        {
            Debug.WriteLine("***** ModifyMapping MauiFestMap");
        });





        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** AppendToMapping {nameof(Entry.TextColor)}");
            var gradientBackground = new GradientDrawable();
            gradientBackground.SetShape(ShapeType.Rectangle);
            gradientBackground.SetColor(Colors.LightGray.ToAndroid());
            gradientBackground.SetStroke(2, view.TextColor.ToAndroid());
            gradientBackground.SetCornerRadius(DpToPixels(handler.PlatformView.Context, Convert.ToSingle(10)));
            handler.PlatformView.Background = gradientBackground;

            handler.PlatformView.SetPadding(
                    (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingTop,
                    (int)DpToPixels(handler.PlatformView.Context, Convert.ToSingle(12)), handler.PlatformView.PaddingBottom);
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** PrependToMapping {nameof(Entry.TextColor)} 1");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** PrependToMapping {nameof(Entry.TextColor)} 2");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(Entry.TextColor), (handler, view, action) =>
        {
            Debug.WriteLine($"***** ModifyMapping {nameof(Entry.TextColor)}");

            //action?.Invoke(handler, view);
        });
    }

    private static float DpToPixels(Context context, float valueInDp)
    {
        DisplayMetrics metrics = context.Resources.DisplayMetrics;
        return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
    }
}
