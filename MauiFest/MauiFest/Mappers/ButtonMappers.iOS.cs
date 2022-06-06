using Microsoft.Maui.Platform;

namespace MauiFest.Mappers;

public class ButtonMappers
{
    public static void CreateHandlers()
    {
        //Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Border", (handler, view) =>
        //{
        //    handler.PlatformView.Layer.CornerRadius = Convert.ToSingle(10);
        //    handler.PlatformView.Layer.BorderColor = Colors.Red.ToCGColor();
        //    handler.PlatformView.Layer.BorderWidth = 2;
        //    handler.PlatformView.ClipsToBounds = true;
        //});

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry.TextColor), (handler, view) =>
        //{
        //    handler.PlatformView.Layer.CornerRadius = Convert.ToSingle(10);
        //    handler.PlatformView.Layer.BorderColor = handler.PlatformView.TextColor.CGColor; //view.TextColor.ToCGColor();
        //    handler.PlatformView.Layer.BorderWidth = 2;
        //    handler.PlatformView.ClipsToBounds = true;
        //});

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        //{
        //    handler.PlatformView.Layer.CornerRadius = Convert.ToSingle(10);
        //    handler.PlatformView.Layer.BorderColor = handler.PlatformView.TextColor.CGColor; //view.TextColor.ToCGColor();
        //    handler.PlatformView.Layer.BorderWidth = 2;
        //    handler.PlatformView.ClipsToBounds = true;
        //});

        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(Entry.TextColor), (handler, view, action) =>
        {
            handler.PlatformView.Layer.CornerRadius = Convert.ToSingle(10);
            handler.PlatformView.Layer.BorderColor = view.TextColor.ToCGColor();
            handler.PlatformView.Layer.BorderWidth = 2;
            handler.PlatformView.ClipsToBounds = true;
            //action?.Invoke(handler, view);
        });
    }
}
