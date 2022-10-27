using Microsoft.AspNetCore.Mvc;

namespace HelloNginx.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    static private readonly Guid TestGuid=Guid.NewGuid();

    [HttpGet("/get")]
    public async Task<Guid> GetGuid()
    {
        return await Task.FromResult(TestGuid);
    }
   
}
