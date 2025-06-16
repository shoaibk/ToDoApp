using System.Text;
using System.Text.Json;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    
    private async void OnLoginSubmit(object? sender, EventArgs e)
    {
        string username = UsernameInput.Text;
        string password = PasswordInput.Text;
        
        
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Input Error", "Username and pass are required", "OK");
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

            var resp = await client.PostAsync("http://localhost:5097/api/auth/login", content);

            if (resp.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful", "OK");
            }
            else
            {
                string error = await resp.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"{error}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Exception", ex.Message, "OK");
        }
    }
}