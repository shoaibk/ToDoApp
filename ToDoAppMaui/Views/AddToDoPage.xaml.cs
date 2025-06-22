using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ToDoAppMaui.Models;

namespace ToDoAppMaui.Views;

public partial class AddToDoPage : ContentPage
{
    private User _user;
    private HttpClient _httpClient= new ();
    
    
    public AddToDoPage(User user)
    {
        InitializeComponent();
        _user = user;
    }

    private async void OnAddTaskClicked(object? sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(title))
        {
          await DisplayAlert("Error", "Title is empty", "Ok");
          return;
        }

        var newTodo = new Todo
        {
            Title = title,
            IsCompleted = false,
        };
        
        var uri = $"http://localhost:5097/api/todo?username={_user.Username}&password={_user.Password}";

        try
        {
            var response = await _httpClient.PostAsJsonAsync(uri, newTodo);
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Error while adding task", "Ok");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Ok");
        }
        
    }
}