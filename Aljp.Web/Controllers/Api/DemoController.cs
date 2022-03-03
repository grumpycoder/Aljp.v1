using Aljp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]", Name = "Demo")]
public class DemoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DemoController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Get()
    {
        var list = await _context.Vendors.ToListAsync();
        return Ok(list);
        
        return Ok(new
        {
            Name = "Demo",
            Message = "Demo message text"
        });
    }
}