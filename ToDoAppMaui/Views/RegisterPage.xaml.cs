using System.Text;
using System.Text.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Input Error", "Username and password are required.", "OK");
            return;
        }

        try
        {
            var client = new HttpClient();
            var request = new User
            {
                Username = username,
                Password = password
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5097/api/auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Registration successful", "OK");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Registration failed: {error}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", ex.Message, "OK");
        }
    }
}