namespace ToDoAppMaui.Models;

public class Todo
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public Todo(string title, bool isCompleted)
    {
        Title = title;
        IsCompleted = isCompleted;
    }
}

