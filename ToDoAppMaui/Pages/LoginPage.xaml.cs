using System.Net.Http.Json;

namespace ToDoAppMaui;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new("http://localhost:5097/")
    };

    public LoginPage() => InitializeComponent();

    private async void OnLoginClicked(object sender, EventArgs e)
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
                               "api/auth/login",
                               new { username, password });

            if (response.IsSuccessStatusCode)
            {
                await ShowMessageAsync("Login successful", true);
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                await ShowMessageAsync(
                    string.IsNullOrWhiteSpace(err)
                        ? "Invalid username or password"
                        : err,
                    false);
            }
        }
        catch (Exception ex)
        {
            await ShowMessageAsync($"Request failed: {ex.Message}", false);
        }
    }

    private Task ShowMessageAsync(string text, bool success) =>
        DisplayAlert(success ? "Success" : "Error", text, "OK");
}
