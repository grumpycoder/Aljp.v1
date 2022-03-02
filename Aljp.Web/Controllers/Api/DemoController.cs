using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]", Name = "Demo")]
public class DemoController : ControllerBase
{
    public async Task<IActionResult> Get()
    {
        return Ok(new
        {
            Name = "Demo",
            Message = "Demo message text"
        });
    }
}