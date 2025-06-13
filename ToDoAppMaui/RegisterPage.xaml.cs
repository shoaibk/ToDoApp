using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMaui;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterClicked(object? sender, EventArgs e)
    {
        var loginUser = new { Username = userEntry.Text, Password = passEntry.Text };
        using var client = new HttpClient();
        var result = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", loginUser);

        if (result.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Your account has been created", "OK");
        }
        else
        {
            await DisplayAlert("oops", "Something went wrong", "OK");
        }
        
    }
}