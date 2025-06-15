using System.Net.Http;
using System.Net.Http.Json;

namespace TodoAppMaui.Views;

public partial class LogInPage : ContentPage // <- FIXED name here
{
    public LogInPage() // <- FIXED constructor name
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
            var response = await httpClient.PostAsJsonAsync("http://10.0.2.2:5097/api/auth/login", user);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Login Failed", error, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Network error: {ex.Message}", "OK");
        }
    }
}