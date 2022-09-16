using interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models.Database;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmpleadoController : Controller
{
    private readonly IEmpleado _empleado;

    public EmpleadoController(IEmpleado empleado)
    {
        _empleado = empleado;
    }

    [HttpGet]
    public async Task<object> Get()
    {
        return await _empleado.All();
    }

    [HttpGet("{id}")]
    public async Task<object> Find(string id)
    {
        return await _empleado.Find(id);
    }

    [HttpPost]
    public async Task<object> Create(Empleado empleado)
    {
        return await _empleado.Create(empleado);
    }

    [HttpPut("{id}")]
    public async Task<object> Update(string id, Empleado empleado)
    {
        empleado.Id = id;
        return await _empleado.Update(empleado);
    }

    [HttpDelete("{id}")]
    public async Task<object> Delete(string id)
    {
        return await _empleado.Delete(id);
    }
}