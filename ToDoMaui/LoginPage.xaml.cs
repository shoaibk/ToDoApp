using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace ToDoMaui;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient client = new();
    
    public LoginPage()
    {
        InitializeComponent();
    }
    
    private async void LoginController(object sender, EventArgs e)
    {
        string username = UsernameLoginEntry.Text?.Trim();
        string password = PasswordLoginEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/login", new
            {
                Username = username,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful", "OK");
            }
            else
            {
                await DisplayAlert("Failed", "Login failed. Check your credentials.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}