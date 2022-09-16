using System.ComponentModel.DataAnnotations.Schema;

namespace models.Database;

[Table("Subarea")]
public class Subarea
{
    #nullable enable
    public string? Id { get; set; }
    public string Nombre { get; set; }
    public string AreaId { get; set; }
    public virtual Area? Area { get; set; }
}