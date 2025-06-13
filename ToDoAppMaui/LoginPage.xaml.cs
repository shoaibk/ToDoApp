using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMaui;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginClicked(object? sender, EventArgs e)
    {
        var newUser = new { Username = userEntry.Text, Password = passEntry.Text };
        using var http = new HttpClient();
        var result = await http.PostAsJsonAsync(" http://localhost:5097/api/auth/login", newUser);

        if (result.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "You have successfully logged in", "OK");
        }
        else
        {
            await DisplayAlert("Failed", "Something went wrong", "OK");
        }
        
    }
}