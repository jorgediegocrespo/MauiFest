using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MauiFest.Mappers;

public static class ButtonMappers
{
    //TODO 4.2 Handlers - mappers
    public static void CreateMappers()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** AppendToMapping MauiFestMap 1");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** AppendToMapping MauiFestMap 2");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** PrependToMapping MauiFestMap 1");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping("MauiFestMap", (handler, view) =>
        {
            Debug.WriteLine("***** PrependToMapping MauiFestMap 2");
        });

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping("MauiFestMap", (handler, view, action) =>
        //{
        //    Debug.WriteLine("***** ModifyMapping MauiFestMap");
        //    action?.Invoke(handler, view);
        //});





        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** AppendToMapping {nameof(Entry.TextColor)} 1");
            handler.PlatformView.Layer.CornerRadius = Convert.ToSingle(10);
            handler.PlatformView.Layer.BorderColor = view.TextColor.ToCGColor();
            handler.PlatformView.Layer.BorderWidth = 2;
            handler.PlatformView.ClipsToBounds = true;
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** AppendToMapping {nameof(Entry.TextColor)} 2");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** PrependToMapping {nameof(Entry.TextColor)} 1");
        });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.PrependToMapping(nameof(Entry.TextColor), (handler, view) =>
        {
            Debug.WriteLine($"***** PrependToMapping {nameof(Entry.TextColor)} 2");
        });

        //Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(Entry.TextColor), (handler, view, action) =>
        //{
        //    Debug.WriteLine($"***** ModifyMapping {nameof(Entry.TextColor)}");
        //    action?.Invoke(handler, view);
        //});
    }
}
