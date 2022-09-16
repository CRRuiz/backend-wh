using interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Database;

namespace api.Controllers;

[Route("cats/[controller]")]
[ApiController]
public class SubareaController : Controller
{
    private readonly ISubarea _subarea;

    public SubareaController(ISubarea subarea)
    {
        _subarea = subarea;
    }

    [HttpGet]
    public async Task<object> Get()
    {
        return await _subarea.All();
    }

    [HttpPost]
    public async Task<object> Create(Subarea subarea)
    {
        return await _subarea.Create(subarea);
    }

    [HttpGet("Area/{id}")]
    public async Task<object> FindArea(string id)
    {
        return await _subarea.FindArea(id);
    }
}