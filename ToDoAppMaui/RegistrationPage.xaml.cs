using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || 
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }

        RegisterButton.IsEnabled = false;
        RegisterButton.Text = "Registering...";

        try
        {
            var apiService = new ApiService();
            var user = new User
            {
                Username = UsernameEntry.Text.Trim(),
                Password = PasswordEntry.Text
            };

            bool success = await apiService.RegisterAsync(user);

            if (success)
            {
                await DisplayAlert("Success", "Registration successful!", "OK");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
                await Shell.Current.GoToAsync("..");  
            }
            else
            {
                await DisplayAlert("Error", "Registration failed. Username might already exist.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Registration error: {ex.Message}", "OK");
        }

        RegisterButton.IsEnabled = true;
        RegisterButton.Text = "Register";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}