using interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Database;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IUsuario _usuario;

    public UsuarioController(IUsuario usuario)
    {
        _usuario = usuario;
    }

    [HttpPost]
    public async Task<object> Create(Usuario usuario)
    {
        return await _usuario.Create(usuario);
    }
}