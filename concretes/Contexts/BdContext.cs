using Microsoft.EntityFrameworkCore;
using models.Database;

namespace concretes.Contexts;

public class BdContext : DbContext
{
    public BdContext(DbContextOptions<BdContext> options) : base(options) {}

    public DbSet<Area> Areas { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Subarea> Subareas { get; set; }
    public DbSet<TipoDocumento> TipoDocumentos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}