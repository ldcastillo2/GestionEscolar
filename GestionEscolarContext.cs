
using GestionEscolar.Models;
using Microsoft.EntityFrameworkCore;

public class GestionEscolarContext(DbContextOptions<GestionEscolarContext> options) : DbContext(options)
{
    public DbSet<GestionEscolar.Models.Estudiante> Estudiante { get; set; } = default!;

    public DbSet<GestionEscolar.Models.Maestro> Maestro { get; set; } = default!;
    public DbSet<GestionEscolar.Models.Aula> Aula { get; set; } = default!;
}
