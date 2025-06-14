using System.Net.Http.Json;
namespace ToDoAppMauiApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterClicked(object? sender, EventArgs e)
    {
        var user = new { Username = usernameEntry.Text, Password = passwordEntry.Text };
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", user);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Your account has been created", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Something went wrong", "OK");
        }
        
    }
}