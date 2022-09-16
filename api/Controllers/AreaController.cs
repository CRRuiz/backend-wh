using interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Database;

namespace api.Controllers;

[Route("cats/[controller]")]
[ApiController]
public class AreaController : Controller
{
    private readonly IArea _area;

    public AreaController(IArea area)
    {
        _area = area;
    }

    [HttpGet]
    public async Task<object> Get()
    {
        return await _area.All();
    }

    [HttpPost]
    public async Task<object> Save(Area area)
    {
        return await _area.Create(area);
    }
}