using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace ToDoMaui;

public partial class RegisterPage : ContentPage
{
    
    private readonly HttpClient client = new();
    
    public RegisterPage()
    {
        InitializeComponent();
    }
    
    private async void RegistrationController(object sender, EventArgs e)
    {
        string username = UsernameRegEntry.Text?.Trim();
        string password = PasswordRegEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both username and password.", "OK");
            return;
        }

        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", new
            {
                Username = username,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Registration successful", "OK");
            }
            else
            {
                await DisplayAlert("Failed", "Registration failed. Try a new username.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}