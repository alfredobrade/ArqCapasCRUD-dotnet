using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoCRUD.Models;

namespace ProyectoCRUD.DAL.DataContext;

public partial class CeCrudArqcapasContext : DbContext
{
    public CeCrudArqcapasContext()
    {
    }

    public CeCrudArqcapasContext(DbContextOptions<CeCrudArqcapasContext> options) : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }
    public object Contacto { get; internal set; }

    /*
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
=> optionsBuilder.UseSqlServer("Server=(local); DataBase=CE_CRUD-ARQCAPAS;Integrated Security=true;TrustServerCertificate=True");// no recomendado la opcion TrustServerCertificate=True
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("CONTACTO");

            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
