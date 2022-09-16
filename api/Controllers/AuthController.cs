using interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuth _auth;

    public AuthController(IAuth auth)
    {
        _auth = auth;
    }
    
    [HttpPost("Login")]
    public async Task<object> Login(models.Request.Auth credentials)
    {
        return await _auth.Login(credentials);
    }
}