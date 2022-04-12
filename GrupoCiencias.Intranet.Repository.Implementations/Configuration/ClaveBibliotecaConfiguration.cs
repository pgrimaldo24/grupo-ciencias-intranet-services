using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ClaveBibliotecaConfiguration : IEntityTypeConfiguration<ClaveBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<ClaveBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idclave)
                   .HasName("pk_clave_biblioteca");

            builder.ToTable("clave_biblioteca");

            builder.HasIndex(e => e.Idclave, "clave_biblioteca_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idsemestre, "relationship_39_fk");

            builder.Property(e => e.Idclave)
                .HasColumnName("idclave")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idsemestre).HasColumnName("idsemestre");

            builder.Property(e => e.NombreClave)
                .HasMaxLength(100)
                .HasColumnName("nombre_clave");

            builder.Property(e => e.UrlClaseRelacionada)
                .HasMaxLength(500)
                .HasColumnName("url_clase_relacionada");

            builder.Property(e => e.UrlClave)
                .HasMaxLength(500)
                .HasColumnName("url_clave");

            builder.HasOne(d => d.IdareaNavigation)
                .WithMany(p => p.ClaveBibliotecas)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("fk_area_clave_biblioteca");

            builder.HasOne(d => d.IdsemestreNavigation)
                .WithMany(p => p.ClaveBibliotecas)
                .HasForeignKey(d => d.Idsemestre)
                .HasConstraintName("fk_clave_bi_relations_semestre");
        }
    }
}
