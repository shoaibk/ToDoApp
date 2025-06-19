using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
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
    

    private async void AddTodo_OnClicked(object? sender, EventArgs e)
    {
        
        var todoE = todoEntry.Text.Trim();
        if (todoE == "") 
        {
            await DisplayAlert("Error", "Todo should not be empty", "OK");
            return;
        }
        
        Todo todo = new();
         
         todo.Title = todoE;
         todo.IsCompleted = false;
        
        await _api.AddTodo(_user, todo);
        
        LoadTodos();
    }
}