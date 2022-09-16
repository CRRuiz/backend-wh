using System.Net;
using concretes.Contexts;
using interfaces;
using Microsoft.EntityFrameworkCore;
using models.Database;
using ServiceStack;

namespace concretes;

public class TipoDocumentoConcrete : ITipoDocumento
{
    private readonly BdContext _context;

    public TipoDocumentoConcrete(BdContext context)
    {
        _context = context;
    }
    
    public async Task<object> All()
    {
        var tipoDocumento = await _context.TipoDocumentos.Select(t => t).ToListAsync();
        return new HttpResult(tipoDocumento, HttpStatusCode.OK);
    }

    public async Task<object> Create(TipoDocumento tipoDocumento)
    {
        var tipoDocumentoDb = new TipoDocumento
        {
            Id = Guid.NewGuid().ToString(),
            Nombre = tipoDocumento.Nombre
        };
        _context.TipoDocumentos.Add(tipoDocumentoDb);
        await _context.SaveChangesAsync();
        return new HttpResult(tipoDocumentoDb, HttpStatusCode.OK);
    }
}