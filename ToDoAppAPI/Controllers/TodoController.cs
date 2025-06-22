using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Data;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController: ControllerBase
{
    private readonly UserDbContext _context;
    public TodoController(UserDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUserTodos([FromQuery] string username, [FromQuery] string password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (user == null) return Unauthorized("Invalid credentials");
        
        var todos = _context.Todos.Where(x => x.UserId == user.Id).ToList();
        return Ok(todos);   
    }

    [HttpPost]
    public IActionResult CreateTodo([FromQuery] string username, [FromQuery] string password, [FromBody] Todo todo)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (user == null) return Unauthorized("Invalid credentials");

        todo.UserId = user.Id;
        _context.Todos.Add(todo);
        _context.SaveChanges();
        return Ok(todo);
    }
    
    [HttpPut]
    public IActionResult UpdateTodo([FromQuery] string username, [FromQuery] string password, [FromBody] Todo todo)
    
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (user == null) return Unauthorized("Invalid credentials");

        var existing = _context.Todos.FirstOrDefault(x => x.Id == todo.Id && x.UserId == user.Id);
        if (existing == null) return NotFound("Todo not found");

        existing.Title = todo.Title;
        existing.IsCompleted = todo.IsCompleted;

        _context.SaveChanges();
        return Ok(existing);
    }
}