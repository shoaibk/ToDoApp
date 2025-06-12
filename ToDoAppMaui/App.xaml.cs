using Microsoft.Maui;
using Microsoft.Maui.Controls;
using ToDoAppMaui.Views;

namespace ToDoAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Start with a NavigationPage hosting our HomePage
            return new Window(new NavigationPage(new HomePage()));
        }
    }
}