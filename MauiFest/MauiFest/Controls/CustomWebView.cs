//TODO 8.1
namespace MauiFest.Controls
{
    public class CustomWebView : WebView
    {
        private Dictionary<string, Action> webButtonClickedCallbacks;
        public Func<string, Task<string>> CustomEvaluateJavaScriptAsync;

        public CustomWebView()
        {
            webButtonClickedCallbacks = new Dictionary<string, Action>();
        }

        public void OnWebButtonClicked(string buttonId)
        {
            if (webButtonClickedCallbacks.ContainsKey(buttonId))
                webButtonClickedCallbacks[buttonId]?.Invoke();
        }

        public async Task StartListenButtonClickEvent(string buttonId, Action clickedCallback)
        {
            if (webButtonClickedCallbacks.ContainsKey(buttonId))
                webButtonClickedCallbacks[buttonId] = clickedCallback;
            else
                webButtonClickedCallbacks.Add(buttonId, clickedCallback);

            string script = GetStartListenButtonClickJavascript(buttonId);
            var result = await CustomEvaluateJavaScriptAsync(script);
        }

        public async Task StopListenButtonClickEvent(string buttonId)
        {
            if (webButtonClickedCallbacks.ContainsKey(buttonId))
                webButtonClickedCallbacks.Remove(buttonId);

            string script = GetStopListenButtonClickJavascript(buttonId);
            await EvaluateJavaScriptAsync(script);
        }

        private string GetStartListenButtonClickJavascript(string buttonId)
        {

#if ANDROID
            string onclickCallback = $"JavascriptFunctions.OnButtonClicked('{buttonId}');";
#elif IOS
            string onclickCallback = $"var callbackParam = 'OnButtonClicked'.concat(';;;', '{buttonId}'); "
               + "window.webkit.messageHandlers.CustomScript.postMessage(callbackParam);";
#endif

            string internalFunctionName = $"{buttonId.Replace("-", string.Empty)}CustomBiidFunction";
            return "javascript: "
                 + $"var {internalFunctionName} = function() "
                 + " { "
                 + $"   {onclickCallback} "
                 + " }; "
                 + $"document.getElementById('{buttonId}').addEventListener('click', {internalFunctionName}); ";
                
        }

        private string GetStopListenButtonClickJavascript(string buttonId)
        {
            return $"javascript: document.getElementById('{buttonId}').removeEventListener('click', {buttonId}CustomBiidFunction);";
        }
    }
}
