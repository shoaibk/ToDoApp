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
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTodos();
    }

    private async Task LoadTodos()
    {
        var todos = await _api.GetTodos(_user);
        todoList.ItemsSource = todos;
    }

    private async void OnAddTaskClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddToDoPage(_user));
    }

    private async void OnTaskCompletedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && checkbox.BindingContext is Todo todo)
        {
            todo.IsCompleted = e.Value;

            var success = await _api.UpdateTodo(_user, todo);

            if (!success)
            {
                checkbox.IsChecked = !e.Value;
            }
        }
    }

}
