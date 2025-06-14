namespace ToDoAppMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("RegistrationPage", typeof(Views.RegistrationPage));
        Routing.RegisterRoute("LoginPage", typeof(Views.LoginPage));
    }
}