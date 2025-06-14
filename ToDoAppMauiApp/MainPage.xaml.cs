namespace ToDoAppMauiApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }


    private async void RegisterClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private async void LoginClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}