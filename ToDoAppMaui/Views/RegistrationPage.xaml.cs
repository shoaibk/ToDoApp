using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui.Views;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnRegistrationClicked(object? sender, EventArgs e)
    {
        var username = usernameEntry.Text;
        var password = passwordEntry.Text;
        var client = new HttpClient();
        var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", new {username, password});
        if (response.IsSuccessStatusCode) await DisplayAlert("Success", "Registration successful", "OK");
        else await DisplayAlert("Error", "Registration failed", "OK");
    }
}