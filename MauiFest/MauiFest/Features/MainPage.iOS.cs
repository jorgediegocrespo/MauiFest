//TODO 6.2
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MauiFest.Features
{
    public partial class MainPage
    {
        private void entryTest2_HandlerChanging(object sender, HandlerChangingEventArgs e)
        {
            Debug.WriteLine($"***** Handel changing OldHandler {e.OldHandler}");
            Debug.WriteLine($"***** Handel changing NewHandler {e.NewHandler}");
        }

        private void entryTest2_HandlerChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"***** Handel changed");
            
            var mauiTextField = (sender as Entry).Handler.PlatformView as MauiTextField;
            mauiTextField.Layer.CornerRadius = Convert.ToSingle(10);
            mauiTextField.Layer.BorderColor = Colors.Pink.ToCGColor();
            mauiTextField.Layer.BorderWidth = 2;
            mauiTextField.ClipsToBounds = true;
        }
    }
}
