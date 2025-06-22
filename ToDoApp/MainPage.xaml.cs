using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
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
    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}