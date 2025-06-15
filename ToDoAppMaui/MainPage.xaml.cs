namespace ToDoAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnGoToRegistrationClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.RegisterPage());
    }

    private async void OnGoToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.LoginPage());
    }
}