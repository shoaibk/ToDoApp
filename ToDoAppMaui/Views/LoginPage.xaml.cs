using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {

            var url = "http://localhost:5097/api/auth/login";


            var payload = new
            {
                username = usernameEntry.Text?.Trim(),
                password = passwordEntry.Text
            };

            try
            {
                using var client = new HttpClient();
                var res = await client.PostAsJsonAsync(url, payload);

                if (res.IsSuccessStatusCode)
                    await DisplayAlert("Success", "Logged in!", "OK");
                else
                    await DisplayAlert("Error", "Invalid username or password.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new RegisterPage());
    }
}