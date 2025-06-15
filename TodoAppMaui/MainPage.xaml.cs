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
    
        await Navigation.PushAsync(new LogInPage());
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
     
        await Navigation.PushAsync(new SignUpPage());
    }
}