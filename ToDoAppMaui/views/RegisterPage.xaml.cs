using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace ToDoAppMaui.views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        var user = new { Username = EntryUsername.Text ,Password = EntryPassword.Text };
        var client = new HttpClient();
        var res = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", user);
        
        if (res.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Account created", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Something wrong", "OK");
        }
    }
}