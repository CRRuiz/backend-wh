using System.ComponentModel.DataAnnotations.Schema;

namespace models.Database;

[Table(("Empleados"))]
public class Empleado
{
    #nullable enable
    public string? Id { get; set; }
    public string TipoDocumentoId { get; set; }
    public virtual TipoDocumento? TipoDocumento { get; set; }
    public string Documento { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string AreaId { get; set; }
    public virtual Area? Area { get; set; }
    public string SubareaId { get; set; }
    public virtual Subarea? Subarea { get; set; }
}