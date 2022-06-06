//TODO 8.3
using Foundation;
using MauiFest.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using UIKit;
using WebKit;

namespace MauiFest.Renderers; 

public class CustomWebViewRenderer : WkWebViewRenderer
{
    public CustomWebViewRenderer() : base(CreateConfiguration())
    {
    }

    private static WKWebViewConfiguration CreateConfiguration()
    {
        var userController = new WKUserContentController();
        var customScriptHandler = new CustomWebViewScriptHandler();
        userController.AddScriptMessageHandler(customScriptHandler, "CustomScript");

        WKPreferences preferences = new WKPreferences()
        {
            JavaScriptEnabled = true,
            JavaScriptCanOpenWindowsAutomatically = true
        };

        var config = new WKWebViewConfiguration
        {
            Preferences = preferences,
            UserContentController = userController
        };

        if (UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
        {
            WKWebpagePreferences defaultWebpagePreferences = new WKWebpagePreferences()
            {
                AllowsContentJavaScript = true,
                PreferredContentMode = WKContentMode.Mobile,
            };

            config.DefaultWebpagePreferences = defaultWebpagePreferences;
        }

        return config;
    }

    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        base.OnElementChanged(e);

        if (e.NewElement != null)
        {
            ((CustomWebView)e.NewElement).CustomEvaluateJavaScriptAsync = CustomEvaluateJavaScriptAsync;
        }
        if (e.OldElement != null)
        {
            ((CustomWebView)e.OldElement).CustomEvaluateJavaScriptAsync = null;
        }
    }

    private async Task<string> CustomEvaluateJavaScriptAsync(string script)
    {
        await EvaluateJavaScriptAsync(script);
        return string.Empty;
    }
}

public class CustomWebViewScriptHandler : NSObject, IWKScriptMessageHandler
{
    public CustomWebViewScriptHandler()
    { }

    public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
    {
        CustomWebViewRenderer customWebViewRenderer = (CustomWebViewRenderer)message.WebView;
        CustomWebView customWebView = (CustomWebView)customWebViewRenderer.Element;
        string[] parameters = message.Body.ToString().Split(";;;");
        string methodName = parameters[0];
        switch (methodName)
        {
            case "OnButtonClicked":
                customWebView?.OnWebButtonClicked(parameters[1]);
                break;
        }
    }
}
