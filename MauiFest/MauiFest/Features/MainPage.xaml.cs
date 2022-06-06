namespace MauiFest.Features;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (entryTest.TextColor == Colors.Green)
        {
            entryTest.TextColor = Colors.Red;
        }
        else
        {
            entryTest.TextColor = Colors.Green;
        }
    }

    //private void btJavascript_Clicked(object sender, EventArgs e)
    //{
    //    Dispatcher.Dispatch(async () => await customWebView.StartListenButtonClickEvent("menu-item-10", ShowMessage));
    //}

    //private void ShowMessage()
    //{
    //    DisplayAlert("Info", "Web button clicker", "OK");
    //}
}

