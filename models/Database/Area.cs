using System.ComponentModel.DataAnnotations.Schema;

namespace models.Database;

[Table("Area")]
public class Area
{
    #nullable enable
    public string? Id { get; set; }
    public string Nombre { get; set; }
}