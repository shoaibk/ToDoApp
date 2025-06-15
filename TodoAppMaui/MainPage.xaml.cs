using Microsoft.Maui.Controls;

namespace TodoAppMaui.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", "Login clicked!", "OK");
        await Navigation.PushAsync(new LogInPage());
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sign Up", "Sign Up clicked!", "OK");
        await Navigation.PushAsync(new SignUpPage());
    }
}