using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Data;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly UserDbContext _context;
    
    public AuthController(UserDbContext context)
    {
        _context = context;    
    }
    
    // create a register endpoint
    [HttpPost("register")]
    //http://localhost:5097/api/auth/register
    public IActionResult Register(User user)
    {
        if(_context.Users.Any(x => x.Username == user.Username)) 
            return BadRequest(new AuthResponse { Success = false, Message = "Username already exists" });
        
        _context.Users.Add(user);     
        _context.SaveChanges();
        return Ok(new AuthResponse { Success = true, Message = "User created successfully" });   
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        var userFromDb = _context.Users.FirstOrDefault(x => 
            x.Username == user.Username && 
            x.Password == user.Password);
        
        if (userFromDb == null) 
            return Unauthorized(new AuthResponse { Success = false, Message = "Invalid username or password" });
        
        return Ok(new AuthResponse { Success = true, Message = "Login successful" });   
    }
}