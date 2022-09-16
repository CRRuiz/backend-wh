using concretes.Contexts;
using concretes.Utils;
using interfaces;
using models.Database;
using ServiceStack;

namespace concretes;

public class UsuarioConcrete : IUsuario
{
    private readonly BdContext _context;

    public UsuarioConcrete(BdContext context)
    {
        _context = context;
    }

    public async Task<object> Create(Usuario usuario)
    {
        Usuario usuarioBd = new Usuario()
        {
            Id = Guid.NewGuid().ToString(),
            Username = usuario.Username,
            Password = Encrypt.GetSHA256(usuario.Password)
        };
        _context.Usuarios.Add(usuarioBd);
        await _context.SaveChangesAsync();
        return new HttpResult(usuario);
    }
}