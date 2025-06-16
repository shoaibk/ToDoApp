using System.Net.Http.Json;
using System.Text.Json;

namespace App;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public LoginPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text?.Trim() ?? "";

        // Basic validation
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }

        try
        {
            // Show loading indicator
            LoginBtn.IsEnabled = false;
            LoginBtn.Text = "Logging in...";

            // Make API request
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5097/api/auth/login", 
                new { username, password });

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Navigation.PopAsync(); // Go back to main page
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Login Failed", 
                    $"Invalid username or password. Please try again.\nError: {response.StatusCode}", "OK");
            }
        }
        catch (HttpRequestException)
        {
            await DisplayAlert("Connection Error", 
                "Unable to connect to the server. Please check your internet connection and try again.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", 
                $"An unexpected error occurred: {ex.Message}", "OK");
        }
        finally
        {
            // Reset button state
            LoginBtn.IsEnabled = true;
            LoginBtn.Text = "Login";
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _httpClient?.Dispose();
    }
}