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

    private async void onAddClicked(object? sender, EventArgs e)
    {
        string title = toDoTitle.Text?.Trim();
        var created = new Todo
        {
            Title = title,
            IsCompleted = false
        };
        
        var newToDo = await _api.AddTodo(_user, created);
        LoadTodos();


    }
}