using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMaui.views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        var user = new { Username = EntryUsername.Text ,Password = EntryPassword.Text };
        var client = new HttpClient();
        var res = await client.PostAsJsonAsync("http://localhost:5097/api/auth/login", user);
        
        if (res.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Logged in", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Something wrong", "OK");
        }
    }
}