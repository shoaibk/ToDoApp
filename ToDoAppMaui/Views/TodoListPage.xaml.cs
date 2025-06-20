using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppMaui.Models;
using ToDoAppMaui.Services;

namespace ToDoAppMaui.Views;

public partial class TodoListPage : ContentPage
{
    private User _user;
    private ApiService _api = new();
    public TodoListPage(User user)
    {
        InitializeComponent();
        _user = user;
        LoadTodos();
    }

    private async Task LoadTodos()
    {
        var todos = await _api.GetTodos(_user);
        todoList.ItemsSource = todos;
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        var inputText = todoEntry.Text.Trim();
        
        if (string.IsNullOrEmpty(inputText))
        {
            await DisplayAlert("Error", "Please Enter Your Todo.", "OK");
            return;
        }
        
        var newTodo = new Todo { Title = inputText };
        
        var isSuccess = await _api.AddTodo(_user, newTodo);
        
        if (isSuccess)
        {
            todoEntry.Text = string.Empty;
            await LoadTodos();
        }
        else
        {
            await DisplayAlert("Error", "Fail to add", "OK");
        }
    }
}