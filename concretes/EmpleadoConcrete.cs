using System.Net;
using concretes.Contexts;
using interfaces;
using Microsoft.EntityFrameworkCore;
using models.Database;
using ServiceStack;

namespace concretes;

public class EmpleadoConcrete : IEmpleado
{
    private readonly BdContext _context;

    public EmpleadoConcrete(BdContext context)
    {
        _context = context;
    }
    
    public async Task<object> All()
    {
        var empleados = await _context.Empleados.Select(e => e).ToListAsync();
        return new HttpResult(empleados, HttpStatusCode.OK);
    }

    public async Task<object> Create(Empleado empleado)
    {
        var empleadoDb = empleado;
        empleadoDb.Id = Guid.NewGuid().ToString();
        _context.Empleados.Add(empleadoDb);
        await _context.SaveChangesAsync();
        return new HttpResult(empleadoDb, HttpStatusCode.OK);
    }

    public async Task<object> Find(string id)
    {
        var empleado = await _context.Empleados.FindAsync(id);
        return new HttpResult(empleado, HttpStatusCode.OK);
    }

    public async Task<object> Update(Empleado empleado)
    {
        _context.Empleados.Update(empleado);
        await _context.SaveChangesAsync();
        return new HttpResult(empleado, HttpStatusCode.OK);
    }

    public async Task<object> Delete(string id)
    {
        var empleado = _context.Empleados.Find(id);

        if (empleado == null)
            return new HttpError(HttpStatusCode.BadRequest, "Empleado no encontrado");
        _context.Empleados.Remove(empleado);
        await _context.SaveChangesAsync();
        return new HttpResult(empleado, HttpStatusCode.OK);
    }
}