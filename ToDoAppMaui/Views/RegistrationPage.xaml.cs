using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class RegistrationPage : ContentPage
{
    private readonly AuthService _authService;

    public RegistrationPage()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var responseMessage = await _authService.RegisterAsync(Username.Text, Password.Text);

        if (responseMessage.Contains("succeeded"))
        {
            await DisplayAlert("Success", "Registration Successful", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Registration Failed", "OK");
        }
    }
}