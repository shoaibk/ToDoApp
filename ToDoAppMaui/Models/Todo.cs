namespace ToDoAppMaui.Models;

public class Todo
{
    public int Id { get; set; }           
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public int UserId { get; set; }     
}
