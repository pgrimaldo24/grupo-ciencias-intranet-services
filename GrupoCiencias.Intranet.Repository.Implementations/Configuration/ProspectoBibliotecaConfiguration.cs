using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ProspectoBibliotecaConfiguration : IEntityTypeConfiguration<ProspectoBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<ProspectoBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idprospecto)
                   .HasName("pk_prospecto_biblioteca");

            builder.ToTable("prospecto_biblioteca");

            builder.HasIndex(e => e.Idprospecto, "prospecto_biblioteca_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idsemestre, "relationship_41_fk");

            builder.HasIndex(e => e.Idarea, "relationship_42_fk");

            builder.Property(e => e.Idprospecto)
                .HasColumnName("idprospecto")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idsemestre).HasColumnName("idsemestre");

            builder.Property(e => e.NombreProspecto)
                .HasMaxLength(100)
                .HasColumnName("nombre_prospecto");

            builder.Property(e => e.UrlClaseRelacionada)
                .HasMaxLength(500)
                .HasColumnName("url_clase_relacionada");

            builder.Property(e => e.UrlProspecto)
                .HasMaxLength(500)
                .HasColumnName("url_prospecto");

            builder.HasOne(d => d.IdareaNavigation)
                .WithMany(p => p.ProspectoBibliotecas)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("fk_prospect_relations_areas_ca");

            builder.HasOne(d => d.IdsemestreNavigation)
                .WithMany(p => p.ProspectoBibliotecas)
                .HasForeignKey(d => d.Idsemestre)
                .HasConstraintName("fk_prospect_relations_semestre");
        }
    }
}
