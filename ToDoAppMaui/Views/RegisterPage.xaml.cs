using System;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views
{
    public partial class RegisterPage : ContentPage
    {
        readonly AuthService _auth = new AuthService();

        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterClicked(object sender, EventArgs e)
        {
            var user = UsernameEntry.Text?.Trim();
            var pass = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            try
            {
                bool ok = await _auth.RegisterAsync(user, pass);
                if (ok)
                {
                    await DisplayAlert("Success", "User created!", "OK");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Error", "User already exists or registration failed.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async void OnLoginTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new LoginPage());
    }
}