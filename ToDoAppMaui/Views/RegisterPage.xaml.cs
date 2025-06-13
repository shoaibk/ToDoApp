using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterClicked(object sender, EventArgs e)
        {

            var url = "http://localhost:5097/api/auth/register";


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
                {
                    await DisplayAlert("Success", "User created!", "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    var msg = await res.Content.ReadAsStringAsync();
                    await DisplayAlert("Error", msg, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void OnLoginTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new LoginPage());
    }
}