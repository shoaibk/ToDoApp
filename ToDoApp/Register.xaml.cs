using System.Net.Http.Json;

namespace ToDoApp;

public partial class RegisterPage : ContentPage
{
    HttpClient client = new HttpClient();

    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var user = new
        {
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        };

        try
        {
            var response = await client.PostAsJsonAsync("http://localhost:5097/api/auth/register", user);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "User created", "OK");
                await Navigation.PopAsync(); 
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
}