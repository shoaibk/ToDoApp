using System;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new LoginPage());

        async void OnRegisterClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new RegisterPage());
    }
}