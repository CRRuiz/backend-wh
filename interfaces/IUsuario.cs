using models.Database;

namespace interfaces;

public interface IUsuario
{
    Task<object> Create(Usuario usuario);
}