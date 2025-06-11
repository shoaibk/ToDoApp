using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace ToDoAppMaui.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
    
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text?.Trim();
        
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Please enter both username and password", "OK");
            return;
        }
        

        var user = new { Username = username, Password = password };
        var client = new HttpClient();
        var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", user);

        
        await DisplayAlert("Success", "Registration successful", "OK");
        await Navigation.PopAsync();
        
        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Registration successful", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Error", error, "OK");
        }
    }
}