namespace ToDoAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("RegistrationPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("LoginPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Navigation failed: {ex.Message}", "OK");
        }
    }
}