using System.Net;
using concretes.Contexts;
using interfaces;
using Microsoft.EntityFrameworkCore;
using models.Database;
using ServiceStack;

namespace concretes;

public class SubareaConcrete : ISubarea
{
    private readonly BdContext _context;

    public SubareaConcrete(BdContext context)
    {
        _context = context;
    }
    
    public async Task<object> All()
    {
        var subareas = await _context.Subareas.Select(s => s).ToListAsync();
        return new HttpResult(subareas, HttpStatusCode.OK);
    }

    public async Task<object> Create(Subarea subarea)
    {
        var subareaDb = new Subarea
        {
            Id = Guid.NewGuid().ToString(),
            Nombre = subarea.Nombre,
            AreaId = subarea.AreaId
        };
        _context.Subareas.Add(subareaDb);
        await _context.SaveChangesAsync();
        return new HttpResult(subareaDb, HttpStatusCode.OK);
    }

    public async Task<object> FindArea(string id)
    {
        var subareas = await _context.Subareas.Where(s => s.AreaId == id).ToListAsync();
        return new HttpResult(subareas, HttpStatusCode.OK);
    }
}