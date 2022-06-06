//TODO 8.2
using Android.Content;
using Android.Webkit;
using Java.Interop;
using MauiFest.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace MauiFest.Renderers;

public class CustomWebViewRenderer : WebViewRenderer
{
    public CustomWebViewRenderer(Context context) : base(context)
    {
    }

    protected override Android.Webkit.WebView CreateNativeControl()
    {
        var nativeWebView = base.CreateNativeControl();
        nativeWebView.Settings.JavaScriptEnabled = true;
        nativeWebView.AddJavascriptInterface(new CustomWebViewJavascriptInterface(Element as CustomWebView), "JavascriptFunctions");

        return nativeWebView;
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Microsoft.Maui.Controls.WebView> e)
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

    private Task<string> CustomEvaluateJavaScriptAsync(string script)
    {
        Control.EvaluateJavascript(script, null);
        return Task.FromResult(string.Empty);
    }
}


public class CustomWebViewJavascriptInterface : Java.Lang.Object
{
    private CustomWebView customWebView;

    public CustomWebViewJavascriptInterface(CustomWebView customWebView)
    {
        this.customWebView = customWebView;
    }

    [JavascriptInterface()]
    [Export("OnButtonClicked")]
    public void OnButtonClicked(string buttonId)
    {
        customWebView.OnWebButtonClicked(buttonId);
    }
}
