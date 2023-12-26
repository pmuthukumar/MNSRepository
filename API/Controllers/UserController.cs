using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context=context;
    }

    [HttpGet]
    public async Task<ActionResult<List<AppUser>>>GetUser()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<AppUser>>GetUser(int Id)
    {
        return await _context.Users.FindAsync(Id);
    }   
}


