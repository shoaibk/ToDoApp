using ToDoAppMaui.Services;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Views;

public partial class AddToDoPage : ContentPage
{
    private User _user;
    private ApiService _api = new ApiService();
    
    public AddToDoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        string inputText = todoInput.Text;

        if (string.IsNullOrEmpty(inputText))
        {
            await DisplayAlert("Error", "Please enter text", "OK");
            return;
        }
        
        inputText = inputText.Trim();

        if (string.IsNullOrEmpty(inputText))
        {
            await DisplayAlert("Error", "Please enter text", "OK");
            return;
        }

        var newToDo = new Todo
        {
            Title = inputText,
            IsCompleted = false
        };
        
        bool success = await _api.AddTodo(_user, newToDo);
        if (success)
        {
            await DisplayAlert("Success", "Your todo item added successfully", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to add your todo item", "OK");
        }
    }
}