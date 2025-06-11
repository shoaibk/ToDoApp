using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace ToDoAppMaui.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text?.Trim();
        
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }
        
        var user = new {Username = username, Password = password};

        var client = new HttpClient();
        var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/login", user);

        await DisplayAlert("Success", "Login Successful", "Ok");
        await Navigation.PopAsync();
        
        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Login Successful", "Ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error",  "Login Failed", "Ok");
        }
    }
}