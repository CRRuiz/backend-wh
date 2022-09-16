using models.Database;

namespace interfaces;

public interface ITipoDocumento
{
    Task<object> All();
    Task<object> Create(TipoDocumento tipoDocumento);
}