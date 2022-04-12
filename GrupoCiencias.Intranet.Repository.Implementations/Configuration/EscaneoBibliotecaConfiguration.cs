using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class EscaneoBibliotecaConfiguration : IEntityTypeConfiguration<EscaneoBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<EscaneoBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idescaneo)
                            .HasName("pk_escaneo_biblioteca");

            builder.ToTable("escaneo_biblioteca");

            builder.HasIndex(e => e.Idescaneo, "escaneo_biblioteca_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idarea, "relationship_37_fk");

            builder.HasIndex(e => e.Idsemestre, "relationship_38_fk");

            builder.Property(e => e.Idescaneo)
                .HasColumnName("idescaneo")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idsemestre).HasColumnName("idsemestre");

            builder.Property(e => e.NombreEscaneo)
                .HasMaxLength(100)
                .HasColumnName("nombre_escaneo");

            builder.Property(e => e.UrlClaseRelacionada)
                .HasMaxLength(500)
                .HasColumnName("url_clase_relacionada");

            builder.Property(e => e.UrlEscaneo)
                .HasMaxLength(500)
                .HasColumnName("url_escaneo");

            builder.HasOne(d => d.IdareaNavigation)
                .WithMany(p => p.EscaneoBibliotecas)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("fk_escaneo__relations_areas_ca");

            builder.HasOne(d => d.IdsemestreNavigation)
                .WithMany(p => p.EscaneoBibliotecas)
                .HasForeignKey(d => d.Idsemestre)
                .HasConstraintName("fk_escaneo__relations_semestre");
        }
    }
}
