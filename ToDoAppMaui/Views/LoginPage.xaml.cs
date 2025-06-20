using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        var username = usernameEntry.Text;
        var password = passwordEntry.Text;
        var client = new HttpClient();
        var user = new User { Username = username, Password = password };
        var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/login", user);
        if (response.IsSuccessStatusCode) await Navigation.PushAsync(new TodoListPage(user));
        else await DisplayAlert("Error", "Login failed", "OK");
    }
}