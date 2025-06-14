using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var responseMessage = await _authService.LoginAsync(Username.Text, Password.Text);

        if (responseMessage.Contains("succeeded"))
        {
            await DisplayAlert("Success", "Login Successful", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Login Failed", "OK");
        }
    }
}