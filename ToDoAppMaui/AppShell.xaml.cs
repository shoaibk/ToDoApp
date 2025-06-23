namespace ToDoAppMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("addtodo", typeof(Views.AddTodoPage));
    }
}