using System.ComponentModel.DataAnnotations.Schema;

namespace models.Database;

[Table("Usuario")]
public class Usuario
{
    #nullable enable
    public string? Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}