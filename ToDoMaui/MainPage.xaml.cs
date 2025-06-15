namespace ToDoMaui;

public partial class MainPage : ContentPage
{
    int count = 0;

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