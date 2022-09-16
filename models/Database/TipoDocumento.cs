using System.ComponentModel.DataAnnotations.Schema;

namespace models.Database;

[Table("TipoDocumento")]
public class TipoDocumento
{
    #nullable enable
    public string? Id { get; set; }
    public string Nombre { get; set; }
}