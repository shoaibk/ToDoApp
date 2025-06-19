using System.Net.Http.Json;

namespace ToDoApp;

public partial class MainPage : ContentPage
{
    HttpClient client = new HttpClient();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var user = new
        {
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        };

        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/login", user);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Login successful", "OK");
            
            }
            else
            {
                var msg = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", msg, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
