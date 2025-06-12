using System;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views
{
    public partial class LoginPage : ContentPage
    {
        readonly AuthService _auth = new AuthService();

        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = UsernameEntry.Text?.Trim();
            var pass = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                
                return;
            }

            try
            {
                bool ok = await _auth.LoginAsync(user, pass);
                if (ok)
                {
                    await DisplayAlert("Success", "Login successful!", "OK");
                    
                }
                else
                {
                    await DisplayAlert("Error", "Invalid username or password.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async void OnRegisterTapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new RegisterPage());
    }
}