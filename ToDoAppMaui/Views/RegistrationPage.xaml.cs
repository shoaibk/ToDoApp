using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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