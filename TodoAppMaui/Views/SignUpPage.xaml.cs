using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace TodoAppMaui.Views
{
    // Define the User model here for local use
    public class User 
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.PostAsJsonAsync("http://10.0.2.2:5097/api/auth/register", user);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Account created!", "OK");
                    await Shell.Current.GoToAsync("//LoginPage");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Signup Failed", error, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Network error: {ex.Message}", "OK");
            }
        }
    }
}