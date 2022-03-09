using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class grupocienciasbdContext : DbContext
    {
        public grupocienciasbdContext()
        {
        }

        public grupocienciasbdContext(DbContextOptions<grupocienciasbdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SolicitudMatricula> SolicitudMatriculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=grupocienciasbd;Username=postgres;Password=Peru123.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudMatricula>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("solicitud_matricula");

                entity.Property(e => e.Apellidos)
                    .HasColumnType("character varying")
                    .HasColumnName("apellidos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombres)
                    .HasColumnType("character varying")
                    .HasColumnName("nombres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
