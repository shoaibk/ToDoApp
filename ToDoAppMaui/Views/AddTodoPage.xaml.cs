using ToDoAppMaui.Models;
using ToDoAppMaui.Services;
using Microsoft.Maui.Controls;

namespace ToDoAppMaui.Views;

public partial class AddTodoPage : ContentPage
{
    private readonly User _user;
    private readonly ApiService _apiService = new();

    public AddTodoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        // Get and trim the input
        var title = TodoTitleEntry.Text?.Trim();

        // Validate input - cannot be empty
        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Error", "Todo title cannot be empty. Please enter a valid title.", "OK");
            return;
        }

        // Disable button to prevent multiple submissions
        AddButton.IsEnabled = false;
        AddButton.Text = "Adding...";

        try
        {
            // Create new todo
            var newTodo = new Todo
            {
                Title = title,
                IsCompleted = false
            };

            // Call API to add todo
            bool success = await _apiService.AddTodoAsync(_user, newTodo);

            if (success)
            {
                await DisplayAlert("Success", "Todo added successfully!", "OK");
                
                // Navigate back to todo list
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Failed to add todo. Please try again.", "OK");
            }
        }
        catch
        {
            await DisplayAlert("Error", "An error occurred while adding todo. Please try again.", "OK");
        }
        finally
        {
            // Re-enable button
            AddButton.IsEnabled = true;
            AddButton.Text = "Add Todo";
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}