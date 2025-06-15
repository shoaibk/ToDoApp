using System.Net.Http;
using System.Net.Http.Json;

namespace TodoAppMaui.Views;

public partial class LogInPage : ContentPage 
{
    public LogInPage()
    {
        InitializeComponent(); 
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Username = usernameEntry.Text,
            Password = passwordEntry.Text
        };

        var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost:5097/api/auth/login", user);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Network error: {ex.Message}", "OK");
        }
    }
}