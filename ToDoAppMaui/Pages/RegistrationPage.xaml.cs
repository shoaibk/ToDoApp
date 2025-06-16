using System.Net.Http.Json;

namespace ToDoAppMaui;

public partial class RegistrationPage : ContentPage
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new("http://localhost:5097/")
    };

    public RegistrationPage() => InitializeComponent();
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var (username, password) = (UsernameEntry.Text?.Trim(), PasswordEntry.Text);

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await ShowMessageAsync("Username and password are required.", false);
            return;
        }

        try
        {
            var response = await _httpClient.PostAsJsonAsync(
                               "api/auth/register",
                               new { username, password });

            var success = response.IsSuccessStatusCode;
            await ShowMessageAsync(success ? "Registration successful"
                                           : "Username unavailable",
                                   success);
        }
        catch (Exception ex)
        {
            await ShowMessageAsync($"Request failed: {ex.Message}", false);
        }
    }

    private Task ShowMessageAsync(string text, bool success) =>
        DisplayAlert(success ? "Success" : "Error", text, "OK");
}
