using System.Net.Http.Json;

namespace ToDoAppMaui;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginClicked(object? sender, EventArgs e)
    {
        var user = new { Username = usernameEntry.Text, Password = passwordEntry.Text };
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync(" http://localhost:5097/api/auth/login", user);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "You have successfully logged in", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Something went wrong", "OK");
        }
        
    }
}