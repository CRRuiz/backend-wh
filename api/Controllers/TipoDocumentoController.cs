using interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Database;

namespace api.Controllers;

[Route("cats/[controller]")]
[ApiController]
public class TipoDocumentoController : Controller
{
    private readonly ITipoDocumento _tipoDocumento;

    public TipoDocumentoController(ITipoDocumento tipoDocumento)
    {
        _tipoDocumento = tipoDocumento;
    }

    [HttpGet]
    public async Task<object> Get()
    {
        return await _tipoDocumento.All();
    }

    [HttpPost]
    public async Task<object> Create(TipoDocumento tipoDocumento)
    {
        return await _tipoDocumento.Create(tipoDocumento);
    }
}