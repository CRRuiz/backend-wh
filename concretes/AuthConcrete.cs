using System.Net;
using concretes.Contexts;
using concretes.Utils;
using interfaces;
using Microsoft.EntityFrameworkCore;
using models.Request;
using ServiceStack;

namespace concretes;

public class AuthConcrete : IAuth
{
    private readonly BdContext _context;
    private readonly IJwtGenerate _jwt;

    public AuthConcrete(BdContext context, IJwtGenerate jwt)
    {
        _context = context;
        _jwt = jwt;
    }
    
    public async Task<object> Login(Auth auth)
    {
        // Buscar si existe el usuario
        var usuarios = _context.Usuarios.Where(us => us.Username == auth.Username).ToListAsync().Result;

        // Verificar que exista el usuario
        if (usuarios.Count > 0)
        {
            var usuario = usuarios[0];
            // Evaluar si las contraseñas son coincidentes
            if (usuario.Password == Encrypt.GetSHA256(auth.Password))
            {
                // Exito, se ha logueado
                models.Response.Auth response = new models.Response.Auth
                {
                    Id = usuario.Id,
                    Username = usuario.Username,
                    Token = _jwt.CreateToken(usuario)
                };
                return new HttpResult(response);
            }
        }
        
        // Retornar error de autentificacion
        return new HttpError(HttpStatusCode.BadRequest, "Usuario o contraseña incorrectos");
    }
}