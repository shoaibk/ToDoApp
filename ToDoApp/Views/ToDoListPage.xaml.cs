using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Services;
using ToDoApp.Models;


namespace ToDoApp.Views;

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
        await Navigation.PushAsync(new AddTodoPage(_user));
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTodos(); // refresh todos on return
    }
}