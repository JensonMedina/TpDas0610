using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MainContext(DbContextOptions<MainContext> options) : DbContext(options)
{
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Sueldo> Sueldos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>().HasKey(e => e.Id);
        modelBuilder.Entity<Empleado>().HasIndex(e => e.Legajo).IsUnique();
        modelBuilder.Entity<Empleado>().Property(e => e.Nombre).HasMaxLength(100);
        modelBuilder.Entity<Empleado>().Property(e => e.Apellido).HasMaxLength(100);
        modelBuilder.Entity<Empleado>().Property(e => e.SueldoBase).HasColumnType("decimal(12,2)");

        base.OnModelCreating(modelBuilder);
    }
}
