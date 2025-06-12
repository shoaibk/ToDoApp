using ToDoAppMaui.views;

namespace ToDoAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }


    private async void OnregisterBtnClicked(object? sender, EventArgs e)
    {
        Console.WriteLine("OnregisterBtnClicked");
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void OnLoginBtnClicked(object? sender, EventArgs e)
    {
        Console.WriteLine("OnLoginBtnClicked");
        await Navigation.PushAsync(new LoginPage());

    }
}