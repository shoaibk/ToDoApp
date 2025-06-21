using ToDoAppMaui.Views;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void OnRegistrationClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}