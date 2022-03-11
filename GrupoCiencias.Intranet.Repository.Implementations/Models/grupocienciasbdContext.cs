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

        public virtual DbSet<Apoderado> Apoderados { get; set; }
        public virtual DbSet<AreasCarrera> AreasCarreras { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Ciclo> Ciclos { get; set; }
        public virtual DbSet<CursosCiclo> CursosCiclos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Solicitude> Solicitudes { get; set; }
        public virtual DbSet<Universidad> Universidads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=grupocienciasbd;Username=postgres;Password=Peru123.;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
