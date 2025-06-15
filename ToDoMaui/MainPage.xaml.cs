namespace ToDoMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    
    {
        InitializeComponent();
    }

    private async void NavController(object sender, EventArgs e)
    {
        if (sender == RegisterNavBtn)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        else if (sender == LoginNavBtn)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}