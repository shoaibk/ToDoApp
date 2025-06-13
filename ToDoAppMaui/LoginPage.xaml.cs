using ToDoAppMaui.Services;
using ToDoAppMaui.Models;

namespace ToDoAppMaui;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || 
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }

        LoginButton.IsEnabled = false;
        LoginButton.Text = "Logging in...";

        try
        {
            var apiService = new ApiService();
            var user = new User
            {
                Username = UsernameEntry.Text.Trim(),
                Password = PasswordEntry.Text
            };

            bool success = await apiService.LoginAsync(user);

            if (success)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Error", "Login failed. Invalid username or password.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Login error: {ex.Message}", "OK");
        }

        LoginButton.IsEnabled = true;
        LoginButton.Text = "Login";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}