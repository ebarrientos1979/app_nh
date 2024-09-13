using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAORepository.Models;

public partial class RhContext : DbContext
{
    public RhContext()
    {
    }

    public RhContext(DbContextOptions<RhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Control> Controls { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer
            ("Server=SCOTIABANK\\SQLEXPRESS;Database=RHDev;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("pk_cargo");

            entity.ToTable("cargo");

            entity.Property(e => e.Idcargo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idcargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.SueldoMax)
                .HasColumnType("money")
                .HasColumnName("sueldo_max");
            entity.Property(e => e.SueldoMin)
                .HasColumnType("money")
                .HasColumnName("sueldo_min");
        });

        modelBuilder.Entity<Control>(entity =>
        {
            entity.HasKey(e => e.Parametro).HasName("pk_control");

            entity.ToTable("control");

            entity.Property(e => e.Parametro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("parametro");
            entity.Property(e => e.Valor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("pk_departamento");

            entity.ToTable("departamento");

            entity.Property(e => e.Iddepartamento)
                .ValueGeneratedNever()
                .HasColumnName("iddepartamento");
            entity.Property(e => e.Idubicacion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idubicacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdubicacionNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.Idubicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_departamento_ubicacion");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("pk_empleado");

            entity.ToTable("empleado");

            entity.Property(e => e.Idempleado)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idempleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Comision)
                .HasColumnType("money")
                .HasColumnName("comision");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fecingreso)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecingreso");
            entity.Property(e => e.Idcargo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idcargo");
            entity.Property(e => e.Iddepartamento).HasColumnName("iddepartamento");
            entity.Property(e => e.Jefe)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("jefe");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sueldo)
                .HasColumnType("money")
                .HasColumnName("sueldo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdcargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleado_cargo");

            entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Iddepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleado_departamento");

            entity.HasOne(d => d.JefeNavigation).WithMany(p => p.InverseJefeNavigation)
                .HasForeignKey(d => d.Jefe)
                .HasConstraintName("fk_empleado_empleado");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Idubicacion).HasName("pk_ubicacion");

            entity.ToTable("ubicacion");

            entity.Property(e => e.Idubicacion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idubicacion");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
