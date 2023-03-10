using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APISmatFut.Models;

public partial class DbsmarfutContext : DbContext
{
    public DbsmarfutContext()
    {
    }

    public DbsmarfutContext(DbContextOptions<DbsmarfutContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Jugador> Jugadors { get; set; }

    public virtual DbSet<Presidente> Presidentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__equipo__3213E83FFE11E79D");

            entity.ToTable("equipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagenEquipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen_equipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Presidente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("presidente");
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__jugador__3213E83F4B6AED33");

            entity.ToTable("jugador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad)
                .HasColumnType("date")
                .HasColumnName("edad");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroCamiseta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_camiseta");

            entity.HasOne(d => d.oEquipo).WithMany(p => p.Jugadors)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__jugador__equipo___6383C8BA");
        });

        modelBuilder.Entity<Presidente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__presiden__3213E83F09132319");

            entity.ToTable("presidente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Presidentes)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__president__equip__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
