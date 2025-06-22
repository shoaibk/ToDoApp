using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace TodoAppMaui.Views
{
    // Local user model
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
                var response = await httpClient.PostAsJsonAsync("http://localhost:5097/api/auth/register", user);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Account created!", "OK");
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    await DisplayAlert("Signup Failed", "Please check your credentials and try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Network error: {ex.Message}", "OK");
            }
        }
    }
}