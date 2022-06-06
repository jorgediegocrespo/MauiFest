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
            entryTest.TextColor = Colors.Red;
        else
            entryTest.TextColor = Colors.Green;
    }
}

