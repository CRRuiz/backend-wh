using System.Net;
using concretes.Contexts;
using interfaces;
using Microsoft.EntityFrameworkCore;
using models.Database;
using ServiceStack;

namespace concretes;

public class AreaConcrete : IArea
{
    private readonly BdContext _context;

    public AreaConcrete(BdContext context)
    {
        _context = context;
    }
    
    public async Task<object> Create(Area area)
    {
        _context.Areas.Add(new Area
        {
            Id = Guid.NewGuid().ToString(),
            Nombre = area.Nombre
        });
        await _context.SaveChangesAsync();
        return new HttpResult(area, HttpStatusCode.OK);
    }

    public async Task<object> All()
    {
        var areas = await _context.Areas.Select(a => a).ToListAsync();
        return new HttpResult(areas, HttpStatusCode.OK);
    }
}