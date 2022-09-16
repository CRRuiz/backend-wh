using models.Database;

namespace interfaces;

public interface IJwtGenerate
{
    string CreateToken(Usuario usuario);
}